using System;
using System.Threading;
using System.Threading.Tasks;
using App.Metrics;

namespace MediatR.Behaviours.Metrics.AppMetrics
{
    public class AppMetricsBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IMetricsRoot _metrics;

        public AppMetricsBehaviour(IMetricsRoot metrics)
        {
            _metrics = metrics;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var tags = new MetricTags("request", request.GetType().Name);

            _metrics.Measure.Meter.Mark(MetricsOptions.MEDIATOR_REQUEST, tags);
            using (_metrics.Measure.Timer.Time(MetricsOptions.MEDIATOR_REQUEST_EXECUTION_TIMER, tags))
            {
                try
                {
                    return await next();
                }
                catch (Exception ex)
                {
                    _metrics.Measure.Meter.Mark(MetricsOptions.MEDIATOR_REQUEST_FAILED, new MetricTags(new string[] { "request", "exception" }, new string[] { request.GetType().Name, ex.GetType().Name }));
                    throw;
                }
            }
        }
    }
}

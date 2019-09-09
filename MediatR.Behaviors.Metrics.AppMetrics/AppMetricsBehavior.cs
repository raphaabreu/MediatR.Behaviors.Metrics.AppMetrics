using System;
using System.Threading;
using System.Threading.Tasks;
using App.Metrics;

namespace MediatR.Behaviors.Metrics.AppMetrics
{
    public class AppMetricsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IMetricsRoot _metrics;

        public AppMetricsBehavior(IMetricsRoot metrics)
        {
            _metrics = metrics;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var tags = new MetricTags("request", request.GetType().Name);

            _metrics.Measure.Meter.Mark(MetricsOptions.MEDIATOR_REQUESTS, tags);
            using (_metrics.Measure.Timer.Time(MetricsOptions.MEDIATOR_REQUESTS_EXECUTION_TIMER, tags))
            {
                try
                {
                    return await next();
                }
                catch (Exception ex)
                {
                    _metrics.Measure.Meter.Mark(MetricsOptions.MEDIATOR_REQUESTS_EXCEPTIONS, new MetricTags(new string[] { "request", "exception" }, new string[] { request.GetType().Name, ex.GetType().FullName }));
                    throw;
                }
            }
        }
    }
}

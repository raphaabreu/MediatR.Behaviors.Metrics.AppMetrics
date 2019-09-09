using App.Metrics;
using App.Metrics.Meter;
using App.Metrics.Timer;

namespace MediatR.Behaviors.Metrics.AppMetrics
{
    internal static class MetricsOptions
    {
        public static readonly TimerOptions MEDIATOR_REQUESTS_EXECUTION_TIMER = new TimerOptions
        {
            Name = "Mediator Requests Execution Time",
            MeasurementUnit = App.Metrics.Unit.Requests,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Seconds,
            Context = "application"
        };

        public static readonly MeterOptions MEDIATOR_REQUESTS = new MeterOptions
        {
            Name = "Mediator Requests",
            MeasurementUnit = App.Metrics.Unit.Requests,
            RateUnit = TimeUnit.Seconds,
            Context = "application"
        };

        public static readonly MeterOptions MEDIATOR_REQUESTS_EXCEPTIONS = new MeterOptions
        {
            Name = "Mediator Requests Exceptions",
            MeasurementUnit = App.Metrics.Unit.Requests,
            RateUnit = TimeUnit.Seconds,
            Context = "application"
        };
    }
}

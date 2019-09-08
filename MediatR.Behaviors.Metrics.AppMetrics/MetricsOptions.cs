using App.Metrics;
using App.Metrics.Meter;
using App.Metrics.Timer;

namespace MediatR.Behaviors.Metrics.AppMetrics
{
    internal static class MetricsOptions
    {
        public static readonly TimerOptions MEDIATOR_REQUEST_EXECUTION_TIMER = new TimerOptions
        {
            Name = "Mediator Request Execution Time",
            MeasurementUnit = App.Metrics.Unit.Requests,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Seconds,
            Context = "application"
        };

        public static readonly MeterOptions MEDIATOR_REQUEST = new MeterOptions
        {
            Name = "Mediator Request",
            MeasurementUnit = App.Metrics.Unit.Requests,
            RateUnit = TimeUnit.Seconds,
            Context = "application"
        };

        public static readonly MeterOptions MEDIATOR_REQUEST_FAILED = new MeterOptions
        {
            Name = "Mediator Request Failed",
            MeasurementUnit = App.Metrics.Unit.Requests,
            RateUnit = TimeUnit.Seconds,
            Context = "application"
        };
    }
}

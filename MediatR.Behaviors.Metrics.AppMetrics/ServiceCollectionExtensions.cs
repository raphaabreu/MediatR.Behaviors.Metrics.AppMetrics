using MediatR.Behaviors.Metrics.AppMetrics;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRAppMetrics(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppMetricsBehavior<,>));

            return services;
        }
    }
}

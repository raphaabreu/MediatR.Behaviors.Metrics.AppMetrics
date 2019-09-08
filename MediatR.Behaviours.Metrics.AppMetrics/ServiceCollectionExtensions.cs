using MediatR.Behaviours.Metrics.AppMetrics;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRAppMetrics(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppMetricsBehaviour<,>));

            return services;
        }
    }
}

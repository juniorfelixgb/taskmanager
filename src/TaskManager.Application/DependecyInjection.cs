using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly);
            });

            return services;
        }
    }
}

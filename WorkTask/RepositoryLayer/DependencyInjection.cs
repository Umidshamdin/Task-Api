using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Repositories;
using RepositoryLayer.Repositories.Interfaces;


namespace RepositoryLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}

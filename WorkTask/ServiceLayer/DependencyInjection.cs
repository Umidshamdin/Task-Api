using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Dtos.Employee;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using FluentValidation;

namespace ServiceLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoggerService, LoggerService>();
            return services;
        }
    }
}

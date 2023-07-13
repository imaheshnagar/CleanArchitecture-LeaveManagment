using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Infrastructure.EmailService;
using LeaveManagement.Application.Contracts.Email;
using LeaveManagement.Application.Models.Email;
using LeaveManagement.Application.Contracts.Logging;
using LeaveManagement.Infrastructure.Logging;

namespace LeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;

        }

    }
}

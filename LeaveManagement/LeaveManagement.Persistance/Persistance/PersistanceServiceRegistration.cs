using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Persistance.DatabaseContext;
using LeaveManagement.Persistance.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistance.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServiceRegistration(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<LmDatabaseContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("LeaveManagementDbConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}

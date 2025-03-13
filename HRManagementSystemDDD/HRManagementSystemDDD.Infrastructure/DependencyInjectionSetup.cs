using HRManagementSystemDDD.Infrastructure.Repositories.Leaves;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemDDD.Infrastructure
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<ILeavesQueryRepository, LeavesQueryRepository>();
            return services;
        }
    }
}

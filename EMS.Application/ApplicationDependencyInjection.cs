using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace EMS.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

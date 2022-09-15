using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicaitonServices(this IServiceCollection services)
        {
             services.AddScoped<IProductRepository,ProductRepository>();
             services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            return services;
        }
    }
}
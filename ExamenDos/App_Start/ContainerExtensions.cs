﻿using BD;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;

namespace ExamenDos
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess> ();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IOrdenService, OrdenService>();
            return services;
        }
    }
}

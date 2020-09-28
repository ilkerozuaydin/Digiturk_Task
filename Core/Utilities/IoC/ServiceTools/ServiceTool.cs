﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC.ServiceTools
{
    public class ServiceTool
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        public static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}

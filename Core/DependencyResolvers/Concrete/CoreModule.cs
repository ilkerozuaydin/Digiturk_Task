using Core.Abstract.DependencyResolvers;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers.Concrete
{
    public class CoreModule : IDependencyResolverModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();

        }
    }
}

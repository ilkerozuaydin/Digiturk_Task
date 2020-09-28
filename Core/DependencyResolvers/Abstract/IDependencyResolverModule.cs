using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract.DependencyResolvers
{
    public interface IDependencyResolverModule
    {
        void Load(IServiceCollection services);
    }
}

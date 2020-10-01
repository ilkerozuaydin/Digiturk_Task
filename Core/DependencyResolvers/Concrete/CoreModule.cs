using Core.Abstract.DependencyResolvers;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.Utilities.Mapper;
using Core.Utilities.Mapper.Mapster;
using Core.Utilities.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers.Concrete
{
    public class CoreModule : IDependencyResolverModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheManager, MemoryCacheManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IMapper, Mapper>();
            services.AddSingleton<ILogger, SeriLogger>();
        }
    }
}
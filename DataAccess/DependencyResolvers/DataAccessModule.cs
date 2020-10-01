using Core.Abstract.DependencyResolvers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyResolvers
{
    public class DataAccessModule : IDependencyResolverModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<ICommentDal, EfCommentDal>();
        }
    }
}
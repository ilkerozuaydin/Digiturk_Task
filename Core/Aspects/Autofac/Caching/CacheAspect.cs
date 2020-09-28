using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC.ServiceTools;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Caching
{
   public class CacheAspect:MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override async void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(t => t?.ToString() ?? "<Null>"))})";

            if (_cacheManager.IsAdded(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            try
            {
                invocation.Proceed();
                if (invocation.ReturnValue != null)
                {
                    var returnType = invocation.Method.ReturnType;
                    if (returnType == typeof(Task) || (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>)))
                    {
                        await (Task)invocation.ReturnValue;
                    }
                    _cacheManager.Add(key, invocation.ReturnValue, _duration);
                }
            }
            catch (System.Exception e)
            {
      
            }
        }
    }
}

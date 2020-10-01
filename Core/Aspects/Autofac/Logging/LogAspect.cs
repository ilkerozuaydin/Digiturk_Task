using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC.ServiceTools;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly ILogger _logger;

        public LogAspect()
        {
            _logger = ServiceTool.ServiceProvider.GetService<ILogger>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _logger.Info(GetLogDetail(invocation));
        }

        private InfoLogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<MethodParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new MethodParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new InfoLogDetail
            {
                MethodName = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}",
                MethodParameters = logParameters
            };

            return logDetail;
        }
    }
}
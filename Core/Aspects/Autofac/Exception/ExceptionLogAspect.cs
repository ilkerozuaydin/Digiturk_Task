using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC.ServiceTools;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private readonly ILogger _logger;

        public ExceptionLogAspect()
        {
            _logger = ServiceTool.ServiceProvider.GetService<ILogger>();
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            _logger.Error(GetLogDetail(invocation, e));
        }

        private ErrorLogDetail GetLogDetail(IInvocation invocation, System.Exception e)
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

            var logDetail = new ErrorLogDetail
            {
                MethodName = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}",
                MethodParameters = logParameters,
                ExceptionMessage = e.Message
            };

            return logDetail;
        }
    }
}

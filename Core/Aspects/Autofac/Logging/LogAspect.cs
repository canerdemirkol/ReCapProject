using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Logging;
using Newtonsoft.Json;

namespace Core.Aspects.Autofac.Logging
{
	public class LogAspect : MethodInterception
	{
		private readonly SerilogLoggerServiceBase _loggerServiceBase;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public LogAspect(Type loggerService)
		{
			if (loggerService.BaseType != typeof(SerilogLoggerServiceBase))
			{
				throw new ArgumentException(AspectMessages.WrongLoggerType);
			}

			_loggerServiceBase = (SerilogLoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
		}
		protected override void OnBefore(IInvocation invocation)
		{
			_loggerServiceBase?.Info(GetLogDetail(invocation));
		}

		private string GetLogDetail(IInvocation invocation)
		{
			var logParameters = new List<LogParameter>();
			for (var i = 0; i < invocation.Arguments.Length; i++)
			{
				logParameters.Add(new LogParameter
				{
					Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
					Value = invocation.Arguments[i],
					Type = invocation.Arguments[i].GetType().Name,


				});
			}
			var logDetail = new LogDetail
			{
				MethodName = invocation.Method.Name,
				Parameters = logParameters,
				User = (_httpContextAccessor.HttpContext == null || _httpContextAccessor.HttpContext.User.Identity.Name == null) ? "?" : _httpContextAccessor.HttpContext.User.Identity.Name

			};
			return JsonConvert.SerializeObject(logDetail);
		}
	}
}

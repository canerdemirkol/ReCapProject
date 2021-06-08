using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Security;
namespace Business.BusinessAspects.Autofac
{
    //JWT icin Aspect
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//JWT token larını herbir client icin ayrı ayrı olustur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            //Aspect oldugu icin bizim yazdıgımız servicleri Aotufac ile inject etmemize yarıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //Windows Form gibi uygulamalarda kullanmak icin (Autofac ile gidip biim yaptıgımız injection ları cözüp getirecek) 
            // productService = ServiceTool.ServiceProvider.GetService<IProductService>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            var methodNane = invocation.Method.Name;
            var path = _httpContextAccessor.HttpContext.Request.Path.Value;
            var method = _httpContextAccessor.HttpContext.Request.Method;
            var host = _httpContextAccessor.HttpContext.Request.Host;


            var notDeniedUrl = " Method : " + method+ "  Api Url : " + host + path ;
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new SecurityException(Messages.AuthorizationDenied+" ---  "+ notDeniedUrl);
        }
    }
}

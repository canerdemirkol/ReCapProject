using Core.ApiDoc;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    //Aspect injection lari icin kullanılacak (injection lari Autofac e devrettigimiz icin)
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMemoryCache(); //IMemoryCache injection icin (MemoryCacheManager daki injection icin) arka planda IMemoryCache instance olusturur
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();

            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerMessages.Version, new OpenApiInfo
                {
                    Version = SwaggerMessages.Version,
                    Title = SwaggerMessages.Title,
                    Description = SwaggerMessages.Description,
                    //TermsOfService = new Uri(SwaggerMessages.TermsOfService),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = SwaggerMessages.ContactName,
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = SwaggerMessages.LicenceName,
                    //},
                });

                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "`Token only!!!` - without `Bearer_` prefix",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
            });
        }

       
    }
}

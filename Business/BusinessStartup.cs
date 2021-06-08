using Autofac;
using Business.Constants;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Business
{
	public partial class BusinessStartup
	{
		protected readonly IHostEnvironment HostEnvironment;


		public BusinessStartup(IConfiguration configuration, IHostEnvironment hostEnvironment)
		{
			Configuration = configuration;
			HostEnvironment = hostEnvironment;
		}

		public IConfiguration Configuration { get; }


		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container. 
		/// </summary>
		/// <remarks>
		/// It is common to all configurations and must be called. Aspnet core does not call this method because there are other methods.
		/// </remarks>
		/// <param name="services"></param>

		public virtual void ConfigureServices(IServiceCollection services)
		{
			

			Func<IServiceProvider, ClaimsPrincipal> getPrincipal = (sp) =>

							sp.GetService<IHttpContextAccessor>().HttpContext?.User ?? new ClaimsPrincipal(new ClaimsIdentity(Messages.Unknown));

			services.AddScoped<IPrincipal>(getPrincipal);


			services.AddDependencyResolvers(Configuration, new ICoreModule[]
			{
					new CoreModule()
			});

			services.AddSingleton<ConfigurationManager>();


			//services.AddTransient<ITokenHelper, JwtHelper>();


			services.AddAutoMapper(typeof(ConfigurationManager));
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
			{
				return memberInfo.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>()?.GetName();
			};

		}

		/// <summary>
		/// This method gets called by the Development
		/// </summary>
		/// <param name="services"></param> 
		public void ConfigureDevelopmentServices(IServiceCollection services)
		{

			ConfigureServices(services);
			//services.AddTransient<IUserRepository, UserRepository>();
			//services.AddTransient<ILogRepository, LogRepository>();
			//services.AddSingleton<IIllerRepository, IllerRepository>();
			//services.AddSingleton<IUsersAllowedToUseAPIRepository, UsersAllowedToUseAPIRepository>();
			services.AddDbContext<ProjectDbContext>();


		}
		/// <summary>		
		/// This method gets called by the Staging
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureStagingServices(IServiceCollection services)
		{
			ConfigureServices(services);
			services.AddDbContext<ProjectDbContext>();



		}

		/// <summary>
		/// This method gets called by the Production
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureProductionServices(IServiceCollection services)
		{
			ConfigureServices(services);
			services.AddDbContext<ProjectDbContext>();
		}


        /// <summary>
        ///  
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacBusinessModule(new ConfigurationManager(Configuration, HostEnvironment)));

        }

    }
}
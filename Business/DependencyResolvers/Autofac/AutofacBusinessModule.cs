using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Adapters.SmsService.NetGSM;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.DataAccess.RepoDb;
using Core.DataAccess.RepoDb.DbConnectionOptions;
using Core.Utilities.Helper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.RepoDb.DbConnection.SqlDatabases;
using FluentValidation;
using NETGSMServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        private readonly ConfigurationManager _configuration;
        public AutofacBusinessModule()
        {
        }

        public AutofacBusinessModule(ConfigurationManager configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<FileHelper>().As<IFileSystem>();

            builder.RegisterType<ReCapDbConnectionFactory>().As<IDatabaseConnectionFactory>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();

            builder.RegisterType<LogRepository>().As<ILogRepository>().SingleInstance();

            builder.RegisterType<IlManager>().As<IIlService>().SingleInstance();
            builder.RegisterType<IlRepository>().As<IIlRepository>().SingleInstance();

            builder.RegisterType<IlcelerManager>().As<IIlceService>().SingleInstance();
            builder.RegisterType<IlceRepository>().As<IIlceRepository>().SingleInstance();

            builder.RegisterType<UsersAllowedToUseAPIManager>().As<IUsersAllowedToUseAPIService>().SingleInstance();
            builder.RegisterType<UsersAllowedToUseAPIRepository>().As<IUsersAllowedToUseAPIRepository>().SingleInstance();

            builder.RegisterType<AdresTipleriManager>().As<IAdresTipService>().SingleInstance();
            builder.RegisterType<AdresTipRepository>().As<IAdresTipRepository>().SingleInstance();

            builder.RegisterType<BolgelerManager>().As<IBolgeService>().SingleInstance();
            builder.RegisterType<BolgeRepository>().As<IBolgeRepository>().SingleInstance();

            builder.RegisterType<CsbmManager>().As<ICsbmService>().SingleInstance();
            builder.RegisterType<CsbmRepository>().As<ICsbmRepository>().SingleInstance();

            builder.RegisterType<MahalleManager>().As<IMahalleService>().SingleInstance();
            builder.RegisterType<MahallelerRepository>().As<IMahalleRepository>().SingleInstance();

            builder.RegisterType<MapKeyManager>().As<IMapKeyService>().SingleInstance();
            builder.RegisterType<MapKeyRepository>().As<IMapKeyRepository>().SingleInstance();

            builder.RegisterType<MobileAppVersionManager>().As<IMobileAppVersionService>().SingleInstance();
            builder.RegisterType<MobileAppVersionRepository>().As<IMobileAppVersionRepository>().SingleInstance();


            builder.RegisterType<SistemOnayKodKontrolManager>().As<ISistemOnayKodKontrolService>().SingleInstance();
            builder.RegisterType<SistemOnayKodKontrolRepository>().As<ISistemOnayKodKontrolRepository>().SingleInstance();


            builder.RegisterType<IletisimTipManager>().As<IIletisimTipService>().SingleInstance();
            builder.RegisterType<IletisimTipRepository>().As<IIletisimTipRepository>().SingleInstance();

            builder.RegisterType<KurumSmsManager>().As<IKurumSmsService>().SingleInstance();
            builder.RegisterType<KurumSmsRepository>().As<IKurumSmsRepository>().SingleInstance();

            //NetGSM service
            builder.RegisterType<smsnnClient>().As<smsnn>().SingleInstance();
            builder.RegisterType<NetGsmSmsAdapterService>().As<INetGsmSmsService>().SingleInstance();
            builder.RegisterType<NetGsmSistemOnayKodManager>().As<INetGsmSistemOnayKodService>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            //       .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                   .AsClosedTypesOf(typeof(IValidator<>));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                           .Where(t => t.FullName.StartsWith("Business.Abstract"));


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                          .Where(t => t.FullName.StartsWith("Business.Concrete"));


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                          .Where(t => t.FullName.StartsWith("DataAccess.Abstract"));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                          .Where(t => t.FullName.StartsWith("DataAccess.Concrete.EntityFramework"));

            //Aspect Interceptors lari aktif etme islemi
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()//implemente edilmis interceptors lari bul
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                   {
                       Selector = new AspectInterceptorSelector()
                   }).SingleInstance().InstancePerDependency();//herkeze ayni instanci ver 
        }
    }
}

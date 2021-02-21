using Autofac;
using Autofac.Integration.WebApi;
using AMS.Database;
using AMS.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using AMS.API.Helpers;

namespace AMS.API
{
    public class AutofacConfig
    {
        private static readonly string _queriesConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(builder);
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register<IUnitOfWork>(c =>
            {
                return new AccountManagementSystemContext();
            }).InstancePerRequest();

            builder.Register(_ => new ConnectionStringProvider(_queriesConnectionString))
               .As<IConnectionStringProvider>();

            //bldr.RegisterType<fffWriteService>()
            //     .As<IfffWriteService>()
            //  .InstancePerRequest();

        }
    }
}
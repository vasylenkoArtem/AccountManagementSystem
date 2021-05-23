﻿using Autofac;
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
using AMS.Helpers;
using AMS.Logic.Queries.UserRoom;
using AMS.Logic.Services;
using AMS.Logic.Queries;
using AMS.Database.MongoDb;
using SmartLab.Logic.Services.Notification.Providers;
using AMS.Database.Repositories;

namespace AMS.API
{
    public class AutofacConfig
    {
        private static readonly string _queriesConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static readonly string _mongodbConnectionString = ConfigurationManager.AppSettings["MongoDbConnection"];
        private static int _apiId => int.Parse(ConfigurationManager.AppSettings["TelegramApiId"]);
        private static readonly string _apiHash = ConfigurationManager.AppSettings["TelegramApiHash"];

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

            builder.RegisterType<UserRoomQueries>()
                 .As<IUserRoomQueries>()
                 .InstancePerRequest();

            builder.RegisterType<UserRoomService>()
                .As<IUserRoomService>()
                .InstancePerRequest();

            builder.RegisterType<UserQueries>()
                .As<IUserQueries>()
                .InstancePerRequest();

            builder.RegisterType<NotificationService>()
                .As<INotificationService>()
                .InstancePerRequest();

            builder.RegisterType<NotificationContext>()
                .As<INotificationContext>()
                .InstancePerRequest();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerRequest();

            builder.Register(_ => new TelegramConnectionStringProvider(_apiId, _apiHash))
               .As<ITelegramConnectionStringProvider>()
               .InstancePerRequest();

            builder.RegisterType<NotificationQueries>()
                .As<INotificationQueries>()
                .InstancePerRequest();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerRequest();



        }
    }
}

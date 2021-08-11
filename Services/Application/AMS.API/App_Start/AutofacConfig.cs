using Autofac;
using Autofac.Integration.WebApi;
using AMS.Database;
using AMS.Domain;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using AMS.Helpers;
using AMS.Logic.Queries.UserRoom;
using AMS.Logic.Services;
using AMS.Logic.Queries;
using AMS.Database.MongoDb;
using SmartLab.Logic.Services.Notification.Providers;
using AMS.Database.Repositories;
using SmartLab.Database;
using SmartLab.Logic.Queries;

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

            builder.RegisterType<AccountManagementSystemContext>()
            .As<IAccountManagementSystemContext>()
            .InstancePerRequest();

            builder.Register(_ => new ConnectionStringProvider(_queriesConnectionString))
               .As<IConnectionStringProvider>();

            builder.Register(_ => new MongoDbConnector(_mongodbConnectionString))
              .As<IMongoDbConnector>();

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

            builder.RegisterType<RoomQueries>()
                .As<IRoomQueries>()
                .InstancePerRequest();

            builder.RegisterType<RoomRepository>()
               .As<IRoomRepository>()
               .InstancePerRequest();

            builder.RegisterType<ComputerRepository>()
              .As<IComputerRepository>()
              .InstancePerRequest();

            builder.RegisterType<ComputerQueries>()
              .As<IComputerQueries>()
              .InstancePerRequest();

            builder.RegisterType<HistoryQueries>()
              .As<IHistoryQueries>()
              .InstancePerRequest();


        }
    }
}

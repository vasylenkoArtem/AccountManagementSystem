using AMS.Domain;
using AMS.Domain.Base;
using AMS.Domain;
using AMS.Domain.IoT;
using AMS.Domain.Printer;
using AMS.Domain;
using SmartLab.Domain;
using SmartLab.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using SmartLab.Database;
using AMS.Helpers;

namespace AMS.Database
{

    public class AccountManagementSystemContext : DbContext, IAccountManagementSystemContext
    {
        public AccountManagementSystemContext() : base("DefaultConnection")
        {

        }

        static AccountManagementSystemContext()
        {
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
            (context as AccountManagementSystemContext).AuditEntries.AddRange(audit.Entries);

            //audit only a subset of our entities, include by interface.
            AuditManager.DefaultConfiguration.Exclude(x => true);
            AuditManager.DefaultConfiguration.Include<IAuditable>();
            AuditManager.DefaultConfiguration.IgnorePropertyAdded = false;

            // used to turn on [AuditExclude] attribute
            AuditManager.DefaultConfiguration.ExcludeDataAnnotation();
            //AuditManager.DefaultConfiguration.SoftDeleted<ISoftDelete>(x => x.IsDeleted);
        }

        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<UserPrinter> UserPrinters { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<UserComputer> UserComputers { get; set; }
        public DbSet<IoTSet> IoTSets { get; set; }
        public DbSet<IoTComponent> IoTComponents { get; set; }
        public DbSet<IoTSetComponent> IoTSetComponents { get; set; }
        public DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }
        public DbSet<UserMessenger> UserMessengers { get; set; }


        public IDbContextTransactionProvider BeginTransaction()
        {
            return new DbContextTransactionProvider(this);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {

                //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                ////use JwtClaimTypes.GivenName, set in Identity.API
                //var currentUser = identity.Claims.Where(c => c.Type == "given_name")
                //       .Select(c => c.Value).SingleOrDefault();

                var currentUser = "Artem Vasylenko";

                AuditManager.DefaultConfiguration.AuditEntryPropertyFactory = args => new AuditEntryProperty();

                var audit = new Audit { CreatedBy = string.IsNullOrEmpty(currentUser) ? "System" : currentUser };
                audit.PreSaveChanges(this);

                var rowsAffected = await this.BatchSaveChangesAsync(options => options.BatchSize = 50, cancellationToken).ConfigureAwait(false);

                audit.PostSaveChanges();

                if (audit.Configuration.AutoSavePreAction != null && audit.Entries.Count > 0)
                {
                    audit.Configuration.AutoSavePreAction(this, audit);
                    await this.BatchSaveChangesAsync(options => options.BatchSize = 100, cancellationToken).ConfigureAwait(false);
                }

            }
            catch (Exception e)
            {
                return false;
                //logger
            }

            return true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // turn off pluralization
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}

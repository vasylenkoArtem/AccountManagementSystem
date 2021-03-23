using AMS.Domain;
using AMS.Domain.Base;
using AMS.Domain.Computer;
using AMS.Domain.IoT;
using AMS.Domain.Printer;
using AMS.Domain.User;
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

namespace AMS.Database
{

    public class AccountManagementSystemContext : DbContext, IUnitOfWork
    {
        public AccountManagementSystemContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<UserPrinter> UserPrinters { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<UserComputer> UserComputers { get; set; }
        public DbSet<IoTSet> IoTSets { get; set; }
        public DbSet<IoTComponent> IoTComponents { get; set; }
        public DbSet<IoTSetComponent> IoTSetComponents { get; set; }


        public IDbContextTransactionProvider BeginTransaction()
        {
            return new DbContextTransactionProvider(this);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await this.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
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

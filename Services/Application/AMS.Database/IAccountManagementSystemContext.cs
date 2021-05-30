using AMS.Domain;
using AMS.Domain.Computer;
using AMS.Domain.IoT;
using AMS.Domain.Printer;
using SmartLab.Domain;
using SmartLab.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Database
{
    public interface IAccountManagementSystemContext : IUnitOfWork
    {
        DbSet<User> Users { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<UserRoom> UserRooms { get; set; }
        DbSet<Printer> Printers { get; set; }
        DbSet<UserPrinter> UserPrinters { get; set; }
        DbSet<Computer> Computers { get; set; }
        DbSet<UserComputer> UserComputers { get; set; }
        DbSet<IoTSet> IoTSets { get; set; }
        DbSet<IoTComponent> IoTComponents { get; set; }
        DbSet<IoTSetComponent> IoTSetComponents { get; set; }
        DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }
        DbSet<UserMessenger> UserMessengers { get; set; }
    }
}

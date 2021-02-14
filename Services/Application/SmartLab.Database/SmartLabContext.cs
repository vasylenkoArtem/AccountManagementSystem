﻿using SmartLab.Domain;
using SmartLab.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace SmartLab.Database
{
   
    public class SmartLabContext : DbContext, IUnitOfWork
    {
        public SmartLabContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }


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
            catch (DbEntityValidationException e)
            {
                //logger


                throw;
            }
            catch (OptimisticConcurrencyException e)
            {
                //logger


                throw;
            }
            catch (DbUpdateConcurrencyException e)
            {
                //logger

                throw;
            }
            catch (Exception e)
            {
                //logger

                throw;
            }

            return true;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Base
{
    public class DbContextTransactionProvider : IDbContextTransactionProvider
    {
        private readonly DbContextTransaction _transaction;

        public DbContextTransactionProvider(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public DbTransaction UnderlyingTransaction => _transaction.UnderlyingTransaction;

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}

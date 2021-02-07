using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Domain
{
    public interface IDbContextTransactionProvider : IDisposable
    {
        DbTransaction UnderlyingTransaction { get; }

        void Commit();
        void Rollback();
    }
}

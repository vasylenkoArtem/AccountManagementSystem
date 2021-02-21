using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransactionProvider BeginTransaction();

        /// <summary>
        /// Asynchronously audits and saves all changes made in this context to the underlying database.
        /// </summary>
        /// <param name="cancellationToken"></param>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}

using SmartLab.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace SmartLab.Logic.Queries
{
    public interface IHistoryQueries
    {
        Task<List<AuditEntry>> GetHistory();
    }

    public class HistoryQueries : IHistoryQueries
    {
        private readonly IAccountManagementSystemContext _context;

        public HistoryQueries(IAccountManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<List<AuditEntry>> GetHistory()
        {
            return await _context.AuditEntries.Include(e => e.Properties).ToListAsync();
        }
    }
}

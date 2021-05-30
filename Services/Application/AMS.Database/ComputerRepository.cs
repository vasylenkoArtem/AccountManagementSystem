using AMS.Domain;
using SmartLab.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Database
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly IAccountManagementSystemContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ComputerRepository(IAccountManagementSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Computer AddComputer(Computer computer)
        {
            return _context.Computers.Add(computer);
        }

        public async Task<Computer> GetAsync(int computerId)
        {
            return await _context.Computers.FindAsync(computerId);
        }

        public async Task<List<Computer>> GetComputersAsync(List<int> ids = null)
        {
            return ids.Any() && ids != null
                 ? await _context.Computers.Where(n => ids.Contains(n.Id)).ToListAsync()
                 : await _context.Computers.ToListAsync();
        }
    }
}

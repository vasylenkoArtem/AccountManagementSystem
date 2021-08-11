using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain
{
    public interface IComputerRepository : IRepository
    {
        Task<Computer> GetAsync(int computerId);

        Task<List<Computer>> GetComputersAsync(List<int> ids = null);

        Computer AddComputer(Computer computer);


    }
}

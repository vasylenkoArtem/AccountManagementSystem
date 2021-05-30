using AMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRoom = AMS.Domain.Room;

namespace AMS.Domain
{
    public interface IRoomRepository : IRepository
    {
        Task<DomainRoom> GetAsync(int roomId);

        Task<List<DomainRoom>> GetRoomsAsync(List<int> ids = null);

        DomainRoom AddRoom(DomainRoom user);

    }
}

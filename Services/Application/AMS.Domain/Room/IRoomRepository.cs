using AMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRoom = AMS.Domain.Room;

namespace AMS.Domain
{
    public interface IRoomRepository
    {
        DomainRoom GetAsync(int roomId);

        List<DomainRoom> GetRooms();

        DomainRoom AddRoom(DomainRoom user);

    }
}

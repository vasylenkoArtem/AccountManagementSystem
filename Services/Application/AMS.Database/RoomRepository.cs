using AMS.Domain;
using SmartLab.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Database.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IAccountManagementSystemContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public RoomRepository(IAccountManagementSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Room> GetAsync(int roomId)
        {
            return await _context.Rooms.FindAsync(roomId);
        }

        public async Task<List<Room>> GetRoomsAsync(List<int> ids = null)
        {
            return ids.Any() && ids != null
                ? await _context.Rooms.Where(n => ids.Contains(n.Id)).ToListAsync()
                : await _context.Rooms.ToListAsync();
        }

        public Room AddRoom(Room room)
        {
            return _context.Rooms.Add(room); ;
        }
    }
}

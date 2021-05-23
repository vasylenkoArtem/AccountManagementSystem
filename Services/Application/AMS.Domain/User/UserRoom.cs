using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain
{
    public class UserRoom
    {
        [Key]
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public int RoomId { get; private set; }

        public bool IsAvaliable { get; private set; }

        public virtual Room Room { get; set; }

        public virtual User User { get; set; }
    }
}

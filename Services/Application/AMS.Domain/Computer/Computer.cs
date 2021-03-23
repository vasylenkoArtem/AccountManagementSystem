using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Computer
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }

        public int OperatingSystemId { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}

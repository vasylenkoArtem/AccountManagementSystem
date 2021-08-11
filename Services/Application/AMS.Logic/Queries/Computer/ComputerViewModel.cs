using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Logic.Queries
{
    public class Computer
    {
        public int Id { get; set; }
        public int OperatingSystemId { get; set; }
        public string OperationSystem { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
    }
}

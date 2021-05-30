using AMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.IoT
{
    public class IoTSetComponent : IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int IoTSetId { get; set; }

        public int IoTComponentId { get; set; }

        public virtual IoTSet IoTSet { get; set; }

        public virtual IoTComponent Component { get; set; }

    }
}

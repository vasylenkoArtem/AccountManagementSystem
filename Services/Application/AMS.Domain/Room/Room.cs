using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Number { get; set; }

        public string Name { get; set; }
    }
}

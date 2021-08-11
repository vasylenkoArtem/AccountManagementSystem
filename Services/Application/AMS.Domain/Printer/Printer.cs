using AMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Printer
{
    public class Printer : IAuditable
    {
        [Key]
        public int Id { get; set; }

        //Need to add other fields
    }
}

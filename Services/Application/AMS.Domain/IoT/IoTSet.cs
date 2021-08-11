using AMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.IoT
{
    public class IoTSet : IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }

        public virtual List<IoTSetComponent> Components { get; set; }


        public IoTSet(string name, int userId, DateTime issuedDate)
        {
            Name = name;
            UserId = userId;
            IssuedDate = issuedDate;
        }

    }
}

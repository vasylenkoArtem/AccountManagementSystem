using AMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainUser = AMS.Domain.User;

namespace AMS.Domain
{
    public class UserComputer : IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int ComputerId { get; set; }

        public int UserId { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public virtual DomainUser User { get; set; }

        public virtual Computer Computer { get; set; }


        public UserComputer(int computerId, int userId, DateTime? validFrom, DateTime? validTo)
        {
            ComputerId = computerId;
            UserId = userId;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

    }
}

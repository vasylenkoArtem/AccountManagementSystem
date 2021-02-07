using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public int UserTypeId { get; set; }

        [Index("IdentityLockUserId_Index")]
        /// <summary>
        /// AspNetUser id that identifies RFID card 
        /// </summary>
        public string IdentityLockUserId { get; set; }
    }
}

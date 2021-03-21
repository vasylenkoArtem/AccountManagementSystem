using AMS.Domain.Computer;
using AMS.Domain.Printer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.User
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



        //TODO: Add index via fluent migration

        //[Index("IdentityLockUserId_Index")]
        /// <summary>
        /// AspNetUser id that identifies RFID card 
        /// </summary>
        public string IdentityLockUserId { get; set; }

        public virtual List<UserPrinter> UserPrinters { get; set; }

        public virtual List<UserComputer> Computers { get; set; }


        public User()
        {
            Computers = new List<UserComputer>();
            UserPrinters = new List<UserPrinter>();
        }
    }
}

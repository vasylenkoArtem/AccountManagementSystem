using AMS.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Domain
{
    public class UserMessenger
    {
        [Key]
        public int Id { get; private set; }

        public int MessengerId { get; private set; }

        public string UserIndetifier { get; private set; }

        public virtual User User { get; set; }

    }
}

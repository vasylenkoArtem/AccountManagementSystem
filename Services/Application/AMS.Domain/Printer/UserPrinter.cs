using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainUser = AMS.Domain.User;

namespace AMS.Domain.Printer
{
    public class UserPrinter
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PrinterId { get; set; }

        public bool IsAvailable { get; set; }

        /// <summary>
        /// JSON Array, if null, means infinite 
        /// </summary>
        public string AllowedPlasticTypes { get; set; }

        /// <summary>
        /// if null, means infinite. Measure in gramms  
        /// </summary>
        public int? AllowedPlasticQuantity { get; set; }

        public virtual DomainUser User { get; set; }

        public UserPrinter(int printerId, List<string> allowedPlasticTypes, int? allowedPlasticQuantity)
        {
            PrinterId = printerId;
            AllowedPlasticTypes = JsonConvert.SerializeObject(allowedPlasticTypes);
            AllowedPlasticQuantity = allowedPlasticQuantity;
        }
    }
}

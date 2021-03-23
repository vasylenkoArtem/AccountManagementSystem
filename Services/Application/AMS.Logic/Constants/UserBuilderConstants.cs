using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Constants
{
    public static class UserBuilderConstants
    {
        public static readonly ReadOnlyCollection<string> AllowedPlasticTypesForStudent =
           new ReadOnlyCollection<string>(new[]
            {
               "ABS",
               "PLA",
               "PVA"
            });

        public static readonly int AllowedPlasticQuantityForStudent = 150;

        public static readonly (DateTime?, DateTime?) ComputerUseValidityDatesForGuest = (DateTime.Now, DateTime.Now.AddDays(1));

    }
}

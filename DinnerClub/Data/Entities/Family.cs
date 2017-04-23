using DinnerClub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerClub.Data.Entities
{
    public class Family : EntityBase
    {
        public string FamilyName { get; set; }

        public ICollection<Person> Members { get; set; }
        
    }
}

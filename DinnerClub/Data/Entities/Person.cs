﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerClub.Data.Entities
{
    public class Person
    {
        public Guid ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Person> Kids { get; set; }

        //Add Username so we can track stuff
    }
}

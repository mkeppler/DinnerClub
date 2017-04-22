using DinnerClub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerClub.Data.Entities
{
    public class EventResponse
    {
        public Guid ID { get; set; }

        public EventResponseEnum Response { get; set; }

        public Event Event { get; set; }
        public Guid EventID { get; set; }

        public Person Person { get; set; }
        public Guid PersonID { get; set; }
    }
}

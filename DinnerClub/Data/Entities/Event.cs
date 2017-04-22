using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerClub.Data.Entities
{
    public class Event
    {
        public Guid ID { get; set; }

        public DateTime Date { get; set; }

        public Restaurant Restaurant { get; set; }
        public Guid RestaurantID { get; set; }

        public ICollection<EventResponse> Responses { get; set; } 
    }
}

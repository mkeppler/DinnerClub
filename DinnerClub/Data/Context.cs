using DinnerClub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerClub.Data
{
    public class Context : DbContext
    {
        //Run add-migration [nameOfMigration]
        //Run update-database
        public Context(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventAttendance> EventAttendance { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}

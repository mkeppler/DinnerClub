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
        //install "SQLite / SQL Server Compact Toolbox" if I want to view the DB

        public DbSet<Person> People { get; set; }
    }
}

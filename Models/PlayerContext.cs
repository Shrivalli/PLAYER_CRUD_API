using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Models
{
    public class PlayerContext:DbContext
    {
        //Injecting DB service.
        public PlayerContext(DbContextOptions<PlayerContext> options):base(options)
        {

        }

        //Creating a Players table.
        public DbSet<Player> Players { get; set; }

    }
}

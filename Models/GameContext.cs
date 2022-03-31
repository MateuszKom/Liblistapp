using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }
    }
}

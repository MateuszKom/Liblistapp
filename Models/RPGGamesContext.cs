using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Models
{
    public class RPGGamesContext : DbContext
    {
        public RPGGamesContext(DbContextOptions<RPGGamesContext> options)
            :base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<RPGGames> RPGGamesInfo { get; set; }
    }
}

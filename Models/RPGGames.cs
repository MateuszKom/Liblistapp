using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Models
{
    public class RPGGames : Game
    {
        public string Genre { get; set; }
        public int Narrative { get; set; }
        public int RPGElements { get; set; }
        public int Art { get; set; }
    }
}

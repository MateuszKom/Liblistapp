using Liblistapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Repositories
{
    public interface IRPGGamesRepository
    {
        Task<IEnumerable<RPGGames>> Get();
        Task<RPGGames> Get(int id);
        Task<RPGGames> Create(RPGGames rpggames);
        Task Update(RPGGames rpggames);
        Task Delete(int id);
        Task<IEnumerable<RPGGames>> GetRPGElements(int RPGElements);
        Task<IEnumerable<RPGGames>> GetRPGGenre(int Genre);
    }
}

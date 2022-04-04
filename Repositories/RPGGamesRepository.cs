using Liblistapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Repositories
{
    public class RPGGamesRepository : IRPGGamesRepository
    {
        private readonly RPGGamesContext _rpggameContext;
        public RPGGamesRepository(RPGGamesContext rpggameContext)
        {
            _rpggameContext = rpggameContext;
        }
        public async Task<RPGGames> Create(RPGGames rpggames)
        {
            _rpggameContext.RPGGamesInfo.Add(rpggames);
            await _rpggameContext.SaveChangesAsync();

            return rpggames;
        }

        public async Task Delete(int id)
        {
            var rpggameToDelete = await _rpggameContext.RPGGamesInfo.FindAsync(id);
            _rpggameContext.RPGGamesInfo.Remove(rpggameToDelete);
            await _rpggameContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RPGGames>> Get()
        {
            return await _rpggameContext.RPGGamesInfo.ToListAsync();
        }

        public async Task<RPGGames> Get(int id)
        {
            return await _rpggameContext.RPGGamesInfo.FindAsync(id);
        }

        public async Task<IEnumerable<RPGGames>> GetRPGElements(int RPGElements)
        {
            return (IEnumerable<RPGGames>)await _rpggameContext.RPGGamesInfo.FindAsync(RPGElements);
        }

        public async Task<IEnumerable<RPGGames>> GetRPGGenre(int Genre)
        {
            return (IEnumerable<RPGGames>)await _rpggameContext.RPGGamesInfo.FindAsync(Genre);
        }

        public async Task Update(RPGGames rpggames)
        {
            _rpggameContext.Entry(rpggames).State = EntityState.Modified;
            await _rpggameContext.SaveChangesAsync();
        }
    }
}

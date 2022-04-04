using Liblistapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _secondcontext;
        public GameRepository(GameContext secondcontext)
        {
            _secondcontext = secondcontext;
        }
        public async Task<Game> Create(Game main)
        {
            _secondcontext.GameInfo.Add(main);
            await _secondcontext.SaveChangesAsync();

            return main;
        }

        public async Task Delete(int id)
        {
            var mainToDelete = await _secondcontext.GameInfo.FindAsync(id);
            _secondcontext.GameInfo.Remove(mainToDelete);
            await _secondcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> Get()
        {
            return await _secondcontext.GameInfo.ToListAsync();
        }

        public async Task<Game> Get(int id)
        {
            return await _secondcontext.GameInfo.FindAsync(id);
        }

        public async Task Update(Game main)
        {
            _secondcontext.Entry(main).State = EntityState.Modified;
            await _secondcontext.SaveChangesAsync();
        }
    }
}

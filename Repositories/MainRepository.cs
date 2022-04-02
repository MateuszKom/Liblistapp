using Liblistapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Repositories
{
    public class MainRepository : IMainRepository
    {
        private readonly MainContext _secondcontext;
        public MainRepository(MainContext secondcontext)
        {
            _secondcontext = secondcontext;
        }
        public async Task<Main> Create(Main main)
        {
            _secondcontext.MainInfo.Add(main);
            await _secondcontext.SaveChangesAsync();

            return main;
        }

        public async Task Delete(int id)
        {
            var mainToDelete = await _secondcontext.MainInfo.FindAsync(id);
            _secondcontext.MainInfo.Remove(mainToDelete);
            await _secondcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Main>> Get()
        {
            return await _secondcontext.MainInfo.ToListAsync();
        }

        public async Task<Main> Get(int id)
        {
            return await _secondcontext.MainInfo.FindAsync(id);
        }

        public async Task Update(Main main)
        {
            _secondcontext.Entry(main).State = EntityState.Modified;
            await _secondcontext.SaveChangesAsync();
        }
    }
}

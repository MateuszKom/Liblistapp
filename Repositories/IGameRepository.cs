using Liblistapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> Get();
        Task<Game> Get(int id);
        Task<Game> Create(Game main);
        Task Update(Game main);
        Task Delete(int id);
    }
}

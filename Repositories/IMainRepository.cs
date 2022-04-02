using Liblistapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Repositories
{
    public interface IMainRepository
    {
        Task<IEnumerable<Main>> Get();
        Task<Main> Get(int id);
        Task<Main> Create(Main main);
        Task Update(Main main);
        Task Delete(int id);
    }
}

using Liblistapp.Models;
using Liblistapp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblistapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPGGameController : ControllerBase
    {
        private readonly IRPGGamesRepository _rpggameRepository;
        public RPGGameController(IRPGGamesRepository rpggameRepository)
        {
            _rpggameRepository = rpggameRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RPGGames>> GetRPGGame()
        {
            return await _rpggameRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<RPGGames> GetRPGGame(int id)
        {
            return await _rpggameRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<RPGGames>> PostRPGGame([FromBody] RPGGames rpggames)
        {
            var newRPGGame = await _rpggameRepository.Create(rpggames);
            return CreatedAtAction(nameof(GetRPGGame), new { id = newRPGGame.ID }, newRPGGame);
        }

        [HttpPut]
        public async Task<ActionResult<RPGGames>> PutRPGGame(int id, [FromBody] RPGGames rpggames)
        {
            if(id == rpggames.ID)
            {
                return BadRequest();
            }
            await _rpggameRepository.Update(rpggames);
            return NoContent();
        }

        [HttpGet("{RPGElements}")]
        public async Task<IEnumerable<RPGGames>> GetRPGElements(int RPGElements)
        {
            return (IEnumerable<RPGGames>)await _rpggameRepository.Get(RPGElements);
        }
    }
}

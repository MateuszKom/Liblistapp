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
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> GetGames()
        {
            return await _gameRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGames(int id)
        {
            return await _gameRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> PostGames([FromBody] Game game)
        {
            var newGame = await _gameRepository.Create(game);
            return CreatedAtAction(nameof(GetGames), new { id = newGame.id }, newGame);
        }

        [HttpPut]
        public async Task<ActionResult<Game>> PutGames(int id, [FromBody] Game game)
        {
            if (id == game.id)
            {
                return BadRequest();
            }
            await _gameRepository.Update(game);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var gameToDelete = await _gameRepository.Get(id);
            if (gameToDelete == null)
            {
                return NotFound();
            }
                
            await _gameRepository.Delete(gameToDelete.id);
            return NoContent();
        }
    }
}

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
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> GetGame()
        {
            return await _gameRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            return await _gameRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> PostGame([FromBody] Game game)
        {
            var newGame = await _gameRepository.Create(game);
            return CreatedAtAction(nameof(GetGame), new { id = newGame.ID }, newGame);
        }

        [HttpPut]
        public async Task<ActionResult<Game>> UpdateGame(int id, [FromBody] Game game)
        {
            if(id == game.ID)
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
            if(gameToDelete == null)
            {
                return NotFound();
            }
            await _gameRepository.Delete(gameToDelete.ID);
            return NoContent();
        }
    }
}

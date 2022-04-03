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
    public class MainController : ControllerBase
    {
        private readonly IMainRepository _mainRepository;

        public MainController(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Main>> GetGame()
        {
            return await _mainRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Main>> GetGame(int id)
        {
            return await _mainRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Main>> PostGame([FromBody] Main main)
        {
            var newMain = await _mainRepository.Create(main);
            return CreatedAtAction(nameof(GetGame), new { id = newMain.ID }, newMain);
        }

        [HttpPut]
        public async Task<ActionResult<Main>> UpdateGame(int id, [FromBody] Main main)
        {
            if(id == main.ID)
            {
                return BadRequest();
            }
            await _mainRepository.Update(main);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var mainToDelete = await _mainRepository.Get(id);
            if(mainToDelete == null)
            {
                return NotFound();
            }
            await _mainRepository.Delete(mainToDelete.ID);
            return NoContent();
        }
    }
}

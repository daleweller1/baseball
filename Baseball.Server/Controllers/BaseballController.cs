using Baseball.Server.Models;
using Baseball.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baseball.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseballController : ControllerBase
    {
        private readonly BaseballService _baseballService;

        public BaseballController(BaseballService baseballService)
        {
            _baseballService = baseballService;
        }

        [HttpGet("players")]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _baseballService.GetPlayersAsync();
            return Ok(players);
        }

        [HttpPut("players/{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] BaseballPlayer updatedPlayer)
        {
            var result = await _baseballService.UpdatePlayerAsync(id, updatedPlayer);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}

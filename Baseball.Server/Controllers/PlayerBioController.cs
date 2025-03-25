using Baseball.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baseball.Server.Controllers
{
    [ApiController]
    [Route("api/playerbio")]
    public class PlayerBioController : ControllerBase
    {
        private readonly PlayerBioService _playerBioService;

        public PlayerBioController(PlayerBioService playerBioService)
        {
            _playerBioService = playerBioService;
        }

        [HttpGet("{playerName}")]
        public async Task<IActionResult> GetBiography(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
                return BadRequest("Player name is required.");

            try
            {
                var bio = await _playerBioService.GenerateBiography(playerName);
                return Ok(new { biography = bio });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating biography: {ex.Message}");
            }
        }
    }
}

using Baseball.Server.Services;
using Microsoft.AspNetCore.Mvc;

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
}

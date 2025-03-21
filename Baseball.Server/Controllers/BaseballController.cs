using Baseball.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BaseballController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public BaseballController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("players")]
    public async Task<IActionResult> GetPlayers()
    {
        var players = await _dbContext.Players.ToListAsync();
        return Ok(players);
    }

    [HttpPut("players/{id}")]
    public async Task<IActionResult> UpdatePlayer(int id, [FromBody] BaseballPlayer updatedPlayer)
    {
        var existingPlayer = await _dbContext.Players.FindAsync(id);
        if (existingPlayer == null)
        {
            return NotFound();
        }

        existingPlayer.Name = updatedPlayer.Name;
        existingPlayer.Position = updatedPlayer.Position;
        existingPlayer.Games = updatedPlayer.Games;
        existingPlayer.AtBats = updatedPlayer.AtBats;
        existingPlayer.Runs = updatedPlayer.Runs;
        existingPlayer.Hits = updatedPlayer.Hits;
        existingPlayer.Doubles = updatedPlayer.Doubles;
        existingPlayer.Triples = updatedPlayer.Triples;
        existingPlayer.HomeRuns = updatedPlayer.HomeRuns;
        existingPlayer.RBIs = updatedPlayer.RBIs;
        existingPlayer.Walks = updatedPlayer.Walks;
        existingPlayer.Strikeouts = updatedPlayer.Strikeouts;
        existingPlayer.StolenBases = updatedPlayer.StolenBases;
        existingPlayer.CaughtStealing = updatedPlayer.CaughtStealing;
        existingPlayer.AVG = updatedPlayer.AVG;
        existingPlayer.OnBasePercentage = updatedPlayer.OnBasePercentage;
        existingPlayer.SluggingPercentage = updatedPlayer.SluggingPercentage;
        existingPlayer.OPS = updatedPlayer.OPS;

        await _dbContext.SaveChangesAsync();
        return Ok(existingPlayer);
    }
}

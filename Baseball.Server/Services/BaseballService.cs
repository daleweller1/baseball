using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Baseball.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Baseball.Server.Services
{
    public class BaseballService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _dbContext;

        public BaseballService(HttpClient httpClient, AppDbContext dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        public async Task<List<BaseballPlayer>> GetPlayersAsync()
        {
            // Return from database if data exists
            if (await _dbContext.Players.AnyAsync())
            {
                return await _dbContext.Players.ToListAsync();
            }

            // Fetch from external API if database is empty
            var response = await _httpClient.GetAsync("https://api.hirefraction.com/api/test/baseball");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var players = JsonSerializer.Deserialize<List<BaseballPlayer>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return players ?? new List<BaseballPlayer>();
        }

        public async Task<BaseballPlayer?> UpdatePlayerAsync(int id, BaseballPlayer updatedPlayer)
        {
            var existingPlayer = await _dbContext.Players.FindAsync(id);
            if (existingPlayer == null) return null;

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
            return existingPlayer;
        }
    }
}

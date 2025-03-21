using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Baseball.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Baseball.Server.Models;

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
            // Check if database already contains player data
            if (await _dbContext.Players.AnyAsync())
            {
                return await _dbContext.Players.ToListAsync();
            }

            // Fetch data from API
            var response = await _httpClient.GetAsync("https://api.hirefraction.com/api/test/baseball");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var players = JsonSerializer.Deserialize<List<BaseballPlayer>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return players;
        }
    }

}

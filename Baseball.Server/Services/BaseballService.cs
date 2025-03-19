using System.Text.Json;
using System.Text.Json.Serialization;

namespace Baseball.Server.Services
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Baseball.Server.Helpers;

    public class BaseballService
    {
        private readonly HttpClient _httpClient;

        public BaseballService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BaseballPlayer>> GetPlayersAsync()
        {
            var response = await _httpClient.GetAsync("https://api.hirefraction.com/api/test/baseball");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<BaseballPlayer>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }

    public class BaseballPlayer
    {
        [JsonPropertyName("Player name")]
        public string Name { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("Games")]
        public int Games { get; set; }

        [JsonPropertyName("At-bat")]
        public int AtBats { get; set; }

        [JsonPropertyName("Runs")]
        public int Runs { get; set; }

        [JsonPropertyName("Hits")]
        public int Hits { get; set; }

        [JsonPropertyName("Double (2B)")]
        public int Doubles { get; set; }

        [JsonPropertyName("third baseman")]
        public int Triples { get; set; }

        [JsonPropertyName("home run")]
        public int HomeRuns { get; set; }

        [JsonPropertyName("run batted in")]
        public int RBIs { get; set; }

        [JsonPropertyName("a walk")]
        public int Walks { get; set; }

        [JsonPropertyName("Strikeouts")]
        public int Strikeouts { get; set; }

        [JsonPropertyName("stolen base")]
        public int StolenBases { get; set; }

        [JsonPropertyName("Caught stealing")]
        [JsonConverter(typeof(StringOrNumberConverter))]
        public string CaughtStealing { get; set; }

        [JsonPropertyName("AVG")]
        public double BattingAverage { get; set; }

        [JsonPropertyName("On-base Percentage")]
        public double OnBasePercentage { get; set; }

        [JsonPropertyName("Slugging Percentage")]
        public double SluggingPercentage { get; set; }

        [JsonPropertyName("On-base Plus Slugging")]
        public double OPS { get; set; }
    }

}

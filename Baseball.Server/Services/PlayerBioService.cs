using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Chat;

namespace Baseball.Server.Services
{
    public class PlayerBioService
    {
        private readonly ChatClient _client;

        public PlayerBioService(IConfiguration configuration)
        {
            string apiKey = configuration["OpenAI:ApiKey"];
            _client = new ChatClient("gpt-4o", apiKey);
        }

        public async Task<string> GenerateBiography(string playerName)
        {
            string chatRequest = $"Generate a short, 4-sentence biography for a baseball player named {playerName}";
            var response = await _client.CompleteChatAsync(chatRequest);
            return response.Value.Content.FirstOrDefault().Text;
        }
    }
}

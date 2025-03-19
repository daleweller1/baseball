using System.Text.Json;
using System.Text.Json.Serialization;

namespace Baseball.Server.Helpers
{
    public class StringOrNumberConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetString();
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt32().ToString(); // Convert number to string
            }
            throw new JsonException($"Unexpected token {reader.TokenType} when parsing a string.");
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }

}

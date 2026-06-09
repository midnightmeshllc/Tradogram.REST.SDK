
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.Utilities
{
    internal class Overrides
    {
        public class NullToFalseBoolConverter : JsonConverter<bool>
        {
            public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    // treat null as false
                    return false;
                }
                return reader.GetBoolean();
            }

            public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
            {
                writer.WriteBooleanValue(value);
            }
        }
    }
}

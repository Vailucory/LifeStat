using System.Text.Json.Serialization;
using System.Text.Json;

namespace LifeStat.Api.Converters;

public class TimeSpanToJsonStringConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return TimeSpan.Parse(reader.GetString()!);
        }
        catch (Exception)
        {
            return TimeSpan.Zero;
        }
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

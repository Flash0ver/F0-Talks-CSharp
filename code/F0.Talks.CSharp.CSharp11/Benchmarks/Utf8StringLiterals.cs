using System.Text;
using System.Text.Json;

namespace F0.Talks.CSharp.CSharp11.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser(false)]
public class Utf8StringLiterals
{
    [Benchmark]
    public string Utf8()
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        writer.WriteStartObject();
        writer.WritePropertyName("names"u8);
        writer.WriteStartArray();
        writer.WriteStringValue("@0x_F0"u8);
        writer.WriteStringValue("@FlashOWare"u8);
        writer.WriteEndArray();
        writer.WritePropertyName("channels"u8);
        writer.WriteStartArray();
        writer.WriteStringValue("twitch.tv/FlashOWare"u8);
        writer.WriteStringValue("youtube.com/@FlashOWare"u8);
        writer.WriteEndArray();
        writer.WriteEndObject();

        writer.Flush();

        string json = Encoding.UTF8.GetString(stream.ToArray());
        return json;
    }

    [Benchmark]
    public string Utf16()
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        writer.WriteStartObject();
        writer.WritePropertyName("names");
        writer.WriteStartArray();
        writer.WriteStringValue("@0x_F0");
        writer.WriteStringValue("@FlashOWare");
        writer.WriteEndArray();
        writer.WritePropertyName("channels");
        writer.WriteStartArray();
        writer.WriteStringValue("twitch.tv/FlashOWare");
        writer.WriteStringValue("youtube.com/@FlashOWare");
        writer.WriteEndArray();
        writer.WriteEndObject();

        writer.Flush();

        string json = Encoding.UTF8.GetString(stream.ToArray());
        return json;
    }
}

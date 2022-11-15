using System.Text.Json;

namespace AdippNet;

public static class Serializer
{
    public static void SerializeToStream(Stream stream, object obj)
    {
        JsonSerializer.Serialize(stream, obj); 
    }

    public static T? DeserializeFromStream<T>(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream);
    }
}
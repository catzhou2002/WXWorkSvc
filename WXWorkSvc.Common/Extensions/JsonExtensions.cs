using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WXWork3rd.Common.Extensions;

public static class JsonExtensions
{
    public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    private static JsonSerializerOptions _OptionsWithIndented = new JsonSerializerOptions()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    //public static T Deserialize<T>(string s) where T : new()
    //    => string.IsNullOrEmpty(s) ? new T() : JsonSerializer.Deserialize<T>(s);

    public static T To<T>(this string s)
    {
        return JsonSerializer.Deserialize<T>(s, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
    //public static T To<T>(this byte[] bytes) => JsonSerializer.Deserialize<T>(new MemoryStream(bytes));
    //public static byte[] ToJsonBytes(this object t) => JsonSerializer.SerializeToUtf8Bytes(t);
    public static string ToJsonString(this object t) => JsonSerializer.Serialize(t, JsonOptions);
    public static string ToJsonStringWithIndented(this object t) => JsonSerializer.Serialize(t, _OptionsWithIndented);

}
using System.Text.Json;

namespace LibraryProject.Infrastructure.Extensions;

public static class JsonExtensions
{
    public static string ToJsonString(this object value)
    {
        if (value is null)
            return default;

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        return System.Text.Json.JsonSerializer.Serialize(value, options);
    }

    public static TModel AsModel<TModel>(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return default;

        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<TModel>(value, options);
    }
}
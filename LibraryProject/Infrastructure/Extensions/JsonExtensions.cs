namespace LibraryProject.Infrastructure.Extensions;

public static class JsonExtensions
{
    /// <summary>
    /// Bir nesneyi JSON biçimine dönüştürmek için kullanılan genişletme yöntemi.
    /// </summary>
    /// <remarks>
    /// Nesnenin JSON biçimine dönüştürülmesi için System.Text.Json kullanır.
    /// </remarks>
    public static string ToJsonString(this object value)
    {
        if (value is null)
            return default;

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        return System.Text.Json.JsonSerializer.Serialize(value, options);
    }
}
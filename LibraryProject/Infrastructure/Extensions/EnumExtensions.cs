namespace LibraryProject.Infrastructure.Extensions;

public static class EnumExtensions
{
    public static int ToInt(this Enum value)
    {
        ArgumentNullException.ThrowIfNull(nameof(value));

        return Convert.ToInt32(value);
    }
}
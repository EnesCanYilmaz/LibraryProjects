namespace LibraryProject.Infrastructure.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Numaralandırma türlerine genişletme yöntemleri eklemek için kullanılan bir statik sınıf.
    /// </summary>
    /// <remarks>
    /// Enum türündeki bir değeri tam sayıya dönüştürmek için bir genişletme yöntemi sağlar.
    /// </remarks>
    public static int ToInt(this Enum value)
    {
        ArgumentNullException.ThrowIfNull(nameof(value));

        return Convert.ToInt32(value);
    }
}
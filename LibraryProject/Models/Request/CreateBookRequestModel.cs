namespace LibraryProject.Models.Request;

/// <summary>
/// Yeni bir kitap oluşturmak için istemci tarafından gönderilen veriyi temsil eden model sınıfı.
/// </summary>
/// <remarks>
/// Kitabın adı, yazarı, görüntü dosyası, kütüphane içinde olup olmadığı ve dönüş tarihi gibi özelliklere sahiptir.
/// </remarks>
public record CreateBookRequestModel
{
    public string Name { get; init; }
    public string Writer { get; init; }
    public IFormFile ImageFile { get; set; }
    public bool IsInLibrary { get; init; } = true;
    public DateTime? ReturnDate { get; init; } = null;
}
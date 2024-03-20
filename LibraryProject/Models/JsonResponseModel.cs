namespace LibraryProject.Models;

/// <summary>
/// JSON yanıtlarını temsil etmek için kullanılan bir sızdırılmış (sealed) sınıf.
/// </summary>
/// <remarks>
/// Hataları, başarı mesajını, yönlendirme URL'sini, başlık bilgisini ve başarılı olup olmadığını içerir.
/// Başarı durumuna bağlı olarak bir simge belirtir.
/// </remarks>
public sealed class JsonResponseModel
{
    public List<string> Errors { get; set; } = new();
    public string SuccessMessage { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public bool IsSuccess => !Errors.Any();
    public string Icon => IsSuccess ? "success" : "error";
}
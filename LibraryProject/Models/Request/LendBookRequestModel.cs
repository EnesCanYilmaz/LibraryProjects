namespace LibraryProject.Models.Request;

/// <summary>
/// Bir kitabı ödünç vermek için istemci tarafından gönderilen veriyi temsil eden kayıt (record) modeli.
/// </summary>
/// <remarks>
/// Kitabın kimliği, dönüş tarihi, ödünç alan kişi ve kütüphane içinde olup olmadığı gibi özelliklere sahiptir.
/// </remarks>
public record LendBookRequestModel
{
    public int Id { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Borrower { get; set; }
    public bool IsInLibrary { get; set; } = false;
}
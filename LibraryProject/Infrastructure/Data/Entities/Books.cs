namespace LibraryProject.Infrastructure.Data.Entities;
/// <summary>
/// Kütüphane projesinin kitap varlığını temsil eden sınıf.
/// BaseHistoricEntity sınıfından türetilmiştir.
/// </summary>
/// <remarks>
/// Kitap adı, yazarı, görüntü yolu, ödünç alan kişi, kütüphane içinde olup olmadığı ve dönüş tarihi gibi özelliklere sahiptir.
/// </remarks>
public class Book : BaseHistoricEntity
{
    public string Name { get; init; }
    public string Writer { get; init; }
    public string ImagePath { get; set; }
    public string? Borrower { get; set; }
    public bool IsInLibrary { get; set; }
    public DateTime? ReturnDate { get; set; }
}
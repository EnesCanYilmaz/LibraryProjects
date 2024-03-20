namespace LibraryProject.Models.Response;

public class GetAllBooksResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Writer { get; set; }
    public string ImagePath { get; init; }
    public string Borrower { get; init; }
    public bool IsInLibrary { get; init; }
    public DateTime? ReturnDate { get; init; }
}
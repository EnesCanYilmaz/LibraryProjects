namespace LibraryProject.Models.Request;

public record LendBookRequestModel
{
    public int Id { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Borrower { get; set; }
    public bool IsInLibrary { get; set; } = false;
}
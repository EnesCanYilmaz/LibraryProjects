namespace LibraryProject.Models.Request;

public class CreateBookRequestModel
{
    public string Name { get; init; }
    public string Writer { get; init; }
    public IFormFile ImageFile { get; set; }
    public bool IsInLibrary { get; init; } = true;
    public DateTime? ReturnDate { get; init; } = null;
}
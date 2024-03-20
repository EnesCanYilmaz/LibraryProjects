namespace LibraryProject.Models;

public sealed class JsonResponseModel
{
    public List<string> Errors { get; set; } = new();
    public string SuccessMessage { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public bool IsSuccess => !Errors.Any();
    public string Icon => IsSuccess ? "success" : "error";
}
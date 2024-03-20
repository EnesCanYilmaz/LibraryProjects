namespace LibraryProject.App.Services.File;

public interface IFileService
{
    Task<(bool,string)> UploadAsync(IFormFile imagePath);
}
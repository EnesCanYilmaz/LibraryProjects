namespace LibraryProject.App.Services.File;

public class FileManager(IWebHostEnvironment webHostEnvironment) : IFileService
{
    public async Task<(bool, string)> UploadAsync(IFormFile imagePath)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(imagePath.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(fileExtension))
            return (false, ExceptionMessage.FileAddedFailed);

        var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath.FileName);
        var uniqueFileName = $"{fileNameWithoutExtension}_{DateTime.Now.Ticks}{fileExtension}";

        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        if (Path.GetInvalidFileNameChars().Intersect(uniqueFileName).Any())
            return (false, ExceptionMessage.FileAddedFailed);

        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await imagePath.CopyToAsync(fileStream);

        return (true, uniqueFileName);
    }
}
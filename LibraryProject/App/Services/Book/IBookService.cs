namespace LibraryProject.App.Services.Book;

public interface IBookService
{
    Task<List<Infrastructure.Data.Entities.Book>> GetAllBooksAsync();
    Task<bool> AddBook(Infrastructure.Data.Entities.Book model);
    Task<bool> LendAsync(LendBookRequestModel model);
    Task<bool> DeliverAsync(int bookId);
}
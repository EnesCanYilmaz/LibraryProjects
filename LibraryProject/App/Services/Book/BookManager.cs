namespace LibraryProject.App.Services.Book;

public class BookManager(IBookRepository bookRepository) : IBookService
{
    public async Task<List<Infrastructure.Data.Entities.Book>> GetAllBooksAsync()
    {
        return await bookRepository.GetAll(filter: null, orderBy: query => query.OrderBy(book => book.Name)).ToListAsync();
    }

    public async Task<bool> AddBook(Infrastructure.Data.Entities.Book model)
    {
        return await bookRepository.InsertAsync(model);
    }

    public async Task<bool> LendAsync(LendBookRequestModel model)
    {
        var book = await bookRepository.GetByIdAsync(model.Id);

        book.ReturnDate = model.ReturnDate;
        book.Borrower = model.Borrower;
        book.IsInLibrary = model.IsInLibrary;

        return await bookRepository.UpdateAsync(book);
    }

    public async Task<bool> DeliverAsync(int bookId)
    {
        var book = await bookRepository.GetByIdAsync(bookId);

        book.Borrower = null;
        book.ReturnDate = null;
        book.IsInLibrary = true;
        
        return await bookRepository.UpdateAsync(book);
    }
}
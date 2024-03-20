namespace LibraryProject.Infrastructure.Data.Repositories.Books;

public class BookRepository(LibraryProjectContext context) : EfEntityRepository<Entities.Book>(context), IBookRepository;
namespace LibraryProject.Infrastructure.Data.UnitOfWork;

public partial interface ILibraryUnitOfWork : IBaseUnitOfWork
{
    /// <summary>
    /// Kitaplar
    /// </summary>
    IBookRepository Books { get; }
}
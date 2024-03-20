namespace LibraryProject.Infrastructure.Data.UnitOfWork;

public sealed class LibraryUnitOfWork : BaseUnitOfWork, ILibraryUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;

    public LibraryUnitOfWork(
        LibraryProjectContext context,
        IServiceProvider serviceProvider) : base(context)
    {
        _serviceProvider = serviceProvider;
    }

    public IBookRepository Books => _serviceProvider.GetRequiredService<IBookRepository>();
}
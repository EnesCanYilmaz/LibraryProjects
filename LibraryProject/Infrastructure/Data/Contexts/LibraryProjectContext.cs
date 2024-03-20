namespace LibraryProject.Infrastructure.Data.Contexts;

public class LibraryProjectContext(DbContextOptions<LibraryProjectContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibraryProjectContext>
    {
        public LibraryProjectContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<LibraryProjectContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new LibraryProjectContext(dbContextOptionsBuilder.Options);
        }
    }
}
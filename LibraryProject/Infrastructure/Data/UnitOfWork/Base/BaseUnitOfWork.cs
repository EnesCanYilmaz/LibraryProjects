namespace LibraryProject.Infrastructure.Data.UnitOfWork.Base;

public class BaseUnitOfWork : IBaseUnitOfWork
{
    private readonly DbContext _context;

    protected BaseUnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public bool SaveChanges()
    {
        try
        {
            var entries = _context.ChangeTracker.Entries().Where(p => p.Entity is BaseHistoricEntity && (p.State == EntityState.Added || p.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }

            return _context.SaveChanges() > 0;
        }
        catch (DbUpdateException exception)
        {
            Log.Fatal(exception, "Veritabanı işlemleri kaydedilirken bir hata oluştu.");
            throw new Exception(GetFullErrorTextAndRollbackEntityChangesAsync(exception).Result, exception);
        }
    }

    public async ValueTask<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var entries = _context.ChangeTracker.Entries().Where(p => p.Entity is BaseHistoricEntity && (p.State == EntityState.Added || p.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        catch (DbUpdateException dbUpdateException)
        {
            Log.Fatal(dbUpdateException, "Veritabanı işlemleri kaydedilirken bir hata oluştu.");
            throw new Exception(await GetFullErrorTextAndRollbackEntityChangesAsync(dbUpdateException), dbUpdateException);
        }
    }

    /// <summary>
    /// Rollback of entity changes and return full error message
    /// </summary>
    /// <param name="dbUpdateException">db update exception</param>
    /// <returns>Error message</returns>
    private async Task<string> GetFullErrorTextAndRollbackEntityChangesAsync(DbUpdateException dbUpdateException)
    {
        if (_context is DbContext dbContext)
        {
            var entries = dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

            entries.ForEach(entry =>
            {
                try
                {
                    entry.State = EntityState.Unchanged;
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    Log.Fatal(invalidOperationException, "Varlığa yapılan değişiklik geri alınırken bir hata oluştu.");
                }
            });
        }

        try
        {
            if (_context != null)
                await _context.SaveChangesAsync();
            return dbUpdateException.ToString();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "Varlığa yapılan değişiklik geri alınırken bir hata oluştu.");
            return exception.ToString();
        }
    }
}
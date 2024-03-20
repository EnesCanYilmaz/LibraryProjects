

namespace LibraryProject.Infrastructure.Data.Repositories.Base;

public class EfEntityRepository<TEntity> : IEfEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly LibraryProjectContext _context;
    private DbSet<TEntity> _entities;

    public EfEntityRepository(LibraryProjectContext context)
    {
        _context = context;
    }

    protected virtual DbSet<TEntity> Entities
    {
        get
        {
            if (_entities is null)
                _entities = _context.Set<TEntity>();

            return _entities;
        }
    }

    private IQueryable<TEntity> Table => Entities;
    private IQueryable<TEntity> TableTracking(bool disableTracking) => disableTracking ? TableNoTracking : Table;
    private IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
    {
        var entityTable = Table.AsQueryable();

        if (filter is not null)
            entityTable = entityTable.Where(filter);

        if (orderBy is not null)
            entityTable = orderBy(entityTable);

        return entityTable;
    }

    private Task<int> SaveAsync() => _context.SaveChangesAsync();

    public virtual async Task<bool> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        ValidateEntity(entity);
        var entityEntry = await Entities.AddAsync(entity, cancellationToken);
        if (entityEntry.State == EntityState.Added)
            return await SaveAsync() > 0;
        return false;
    }

    public async Task<bool> UpdateAsync(TEntity model)
    {
        var entityEntry = Entities.Update(model);
        if (entityEntry.State == EntityState.Modified)
            return await SaveAsync() > 0;
        return false;
    }
    
    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await Entities.FindAsync(id);
        if (entity is null)
            throw new InvalidOperationException(ExceptionMessage.EntityRequired);
        
        return entity;
    }

    private static void ValidateEntity(TEntity entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), ExceptionMessage.EntityRequired);
    }
}
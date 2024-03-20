namespace LibraryProject.Infrastructure.Data.Repositories.Base;

public interface IEfEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy);
    Task<bool> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> GetByIdAsync(int id);
    Task<bool> UpdateAsync(TEntity model);
}
namespace LibraryProject.Infrastructure.Data.UnitOfWork.Base;

public interface IBaseUnitOfWork
{
    /// <summary>
    /// Begin Transaction
    /// </summary>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>type of dbcontext transaction interface</returns>
    /// <exception cref="OperationCanceledException">when the transaction fails</exception>
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Save changes synchronous
    /// </summary>
    /// <remarks>method that can be overridden</remarks>
    /// <returns>type of integer</returns>
    /// <exception cref="Exception">when transferring data to database</exception>
    bool SaveChanges();

    /// <summary>
    /// Save changes asynchronous
    /// </summary>
    /// <remarks>method that can be overridden</remarks>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>type of integer</returns>
    /// <exception cref="Exception">when transferring data to database</exception>
    ValueTask<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
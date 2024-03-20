namespace LibraryProject.Infrastructure.Data.Entities.Base;

public class BaseEntity : IEntity
{
    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    public int Id { get; init; }
}
public abstract class BaseHistoricEntity : BaseEntity
{
    /// <summary>
    /// Gets or sets created date
    /// </summary>
    public DateTime CreatedDate { get; init; }

    /// <summary>
    /// Gets or sets updated date
    /// </summary>
    public DateTime? UpdatedDate { get; init; }
}
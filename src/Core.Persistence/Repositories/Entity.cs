using Core.Persistence.Interfaces;

namespace Core.Persistence.Repositories;

public abstract class Entity<TId> : IEntity<TId>, IEntityUserActions<TId>, IEntityTimestamps
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public TId CreatedUserId { get; set; }
    public TId? UpdatedUserId { get; set; }
    public TId? DeletedUserId { get; set; }

    protected Entity()
    {
        Id = default!;
    }

    protected Entity(TId id)
    {
        Id = id;
    }
}
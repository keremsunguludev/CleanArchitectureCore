namespace Core.Persistence.Interfaces;

public interface IEntityUserActions<T>
{
    public T CreatedUserId { get; set; }
    public T? UpdatedUserId { get; set; }
    public T? DeletedUserId { get; set; }
}
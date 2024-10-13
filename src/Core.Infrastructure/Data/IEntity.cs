namespace Core.Infrastructure.Data;

public interface IEntity<T>
{
    T Id { get; set; }
}
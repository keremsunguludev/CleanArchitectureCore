namespace Core.Persistence.Interfaces;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
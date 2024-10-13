namespace Core.Infrastructure.Interfaces;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
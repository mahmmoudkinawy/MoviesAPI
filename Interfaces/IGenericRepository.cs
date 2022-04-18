namespace MoviesAPI.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
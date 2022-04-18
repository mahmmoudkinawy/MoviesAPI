namespace MoviesAPI.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MoviesDbContext _context;

    public GenericRepository(MoviesDbContext context) => _context = context;

    public async Task Add(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = _context.Set<T>();

        if (filter != null)
            query = query.Where(filter);

        return await query.FirstOrDefaultAsync();
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
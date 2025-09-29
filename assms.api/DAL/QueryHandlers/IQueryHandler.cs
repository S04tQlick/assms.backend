namespace assms.api.DAL.QueryHandlers;

public interface IQueryHandler<T> where T : BaseModel
{
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    Task<IEnumerable<T>> GetAllByDateAsync(DateTime date, params Expression<Func<T, object>>[] includeProperties);
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
    Task<int> CreateAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
}
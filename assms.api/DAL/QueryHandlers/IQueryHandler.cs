using assms.entities.Models;

namespace assms.api.DAL.QueryHandlers;

public interface IQueryHandler<T> where T : BaseModel
{
    Task<IEnumerable<T>> GetAllByDateAsync(DateTime date);
    Task<T?> GetByIdAsync(Guid id);
    Task<int> CreateAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(Guid id);
}
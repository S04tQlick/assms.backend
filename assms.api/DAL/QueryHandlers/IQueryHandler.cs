using assms.entities.Models;

namespace assms.api.DAL.QueryHandlers;

public interface IQueryHandler
{
    public interface IQueryHandler<T> where T : BaseModel
    {
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllByDateAsync(DateTime date);
    } 
}
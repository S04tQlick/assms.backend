using System.Linq.Expressions;
using assms.api.DAL.DatabaseContext;
using assms.entities.Models;
using Microsoft.EntityFrameworkCore;

namespace assms.api.DAL.QueryHandlers;

public class QueryHandler<T>(ApplicationDbContext ctx) : IQueryHandler<T> where T : BaseModel
{
    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[]? includes)
    {
        IQueryable<T> query = ctx.Set<T>();

        if (includes == null) return await query.ToListAsync();
        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.ToListAsync();
    }

    // public async Task<IEnumerable<T>> GetAllByInstitutionAsync(Guid id, params Expression<Func<T, object>>[]? includes)
    // {
    //     IQueryable<T> query = ctx.Set<T>().Where(o => o.Id == id);
    //
    //     if (includes == null) return await query.ToListAsync();
    //     query = includes.Aggregate(query, (current, include) => current.Include(include));
    //
    //     return await query.ToListAsync();
    // }

    public async Task<IEnumerable<T>> GetAllByDateAsync(DateTime date, params Expression<Func<T, object>>[]? includes)
    {
        IQueryable<T> query = ctx.Set<T>();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);

        return await query.Where(e => e.CreatedAt.Date == utcDate).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[]? includes)
    {
        IQueryable<T> query = ctx.Set<T>();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> CreateAsync(T entity)
    {
        ctx.Set<T>().Add(entity);
        return await ctx.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        ctx.Set<T>().Update(entity);
        return await ctx.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var entity = await ctx.Set<T>().FindAsync(id);
        if (entity == null) return 0;

        ctx.Set<T>().Remove(entity);
        return await ctx.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await ctx.Set<T>().AnyAsync(predicate);
    }
}
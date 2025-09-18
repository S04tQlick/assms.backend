using assms.api.DAL.DatabaseContext;
using assms.entities.Models;
using Microsoft.EntityFrameworkCore;

namespace assms.api.DAL.QueryHandlers;

public class QueryHandler<T>(ApplicationDbContext ctx) : IQueryHandler<T> where T : BaseModel
{
    public async Task<IEnumerable<T>> GetAllByDateAsync(DateTime date)
    {
        var statUtc = DateTime.SpecifyKind(date, DateTimeKind.Utc);
        return await ctx.Set<T>()
            .Where(x => x.CreatedAt >= statUtc && x.CreatedAt <= statUtc.AddDays(1))
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
       return await ctx.Set<T>().FindAsync(id);
    }
    
    public async Task<int> CreateAsync(T entity)
    {
        if (ctx.Set<T>().Any()) throw new Exception("Entity has been already created");
        await ctx.AddAsync(entity);
        return await ctx.SaveChangesAsync();
    }

    public Task<int> UpdateAsync(T entity)
    {
        ctx.Set<T>().Update(entity);
        return ctx.SaveChangesAsync();
    }

    public Task<int> DeleteAsync(Guid id)
    {
       var entity = ctx.Set<T>().Find(id);
       if (entity == null) return Task.FromResult(0);

       ctx.Set<T>().Remove(entity);
       return ctx.SaveChangesAsync();
    }
}
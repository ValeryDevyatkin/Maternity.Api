using Maternity.Application.Repository.Common;
using Maternity.Domain.Model.Common;
using Maternity.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Maternity.Persistence.Repository.Common;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
{
    protected MaternityDbContext Context { get; }

    public RepositoryBase(MaternityDbContext context)
    {
        Context = context;
    }

    public async Task<T> CreateAsync(T item)
    {
        var createdItem = await Context.Set<T>().AddAsync(item);
        await Context.SaveChangesAsync();

        return createdItem.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await Context.Set<T>().FindAsync(id);

        if (item == null) {
            return false;
        }

        Context.Set<T>().Remove(item);
        await Context.SaveChangesAsync();

        return true;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetManyAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T item)
    {
        Context.Entry(item).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
}
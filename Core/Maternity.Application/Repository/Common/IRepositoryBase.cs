using Maternity.Domain.Model.Common;

namespace Maternity.Application.Repository.Common;

public interface IRepositoryBase<T> where T : ModelBase
{
    Task<IEnumerable<T>> GetManyAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T item);
    Task UpdateAsync(T item);
    Task<bool> DeleteAsync(int id);
}
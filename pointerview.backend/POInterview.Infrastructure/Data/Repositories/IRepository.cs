using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Infrastructure.Data.Repositories;

public interface IRepository<T> where T : EntityBase, new()
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task DeleteByIdAsync(int id);
}

using System.Linq.Expressions;

namespace CDatos.Repositories.Contracts
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task SaveAsync();
    }
}
using System.Linq.Expressions;

namespace CDatos.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        bool Save();
    }
}

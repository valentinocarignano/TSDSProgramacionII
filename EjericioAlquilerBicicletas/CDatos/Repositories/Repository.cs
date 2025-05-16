using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CDatos.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AlquilerBiciletasContext _context { get; set; }

        public Repository(AlquilerBiciletasContext context)
        {
            this._context = context;
        }

        public IEnumerable<T> FindAll()
        {
            return this._context.Set<T>().ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).ToList();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

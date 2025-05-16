using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CDatos.Repositories.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context { get; set; }

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
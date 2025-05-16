using CEntidades.Entities;
using System.Linq.Expressions;

namespace CDatos.Repositories.Contracts
{
    public interface IAtencionRepository : IRepository<Atencion>
    {
        new Task<IEnumerable<Atencion>> FindAllAsync();
        new Task<IEnumerable<Atencion>> FindByConditionAsync(Expression<Func<Atencion, bool>> expression);
    }
}
using CEntidades.Entities;
using System.Linq.Expressions;

namespace CDatos.Repositories.Contracts
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        new Task<IEnumerable<Animal>> FindAllAsync();
        new Task<IEnumerable<Animal>> FindByConditionAsync(Expression<Func<Animal, bool>> expression);
    }
}
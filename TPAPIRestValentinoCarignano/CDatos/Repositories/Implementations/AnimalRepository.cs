using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CDatos.Repositories.Implementations
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(AppDbContext context) : base(context)
        {
            
        }

        public override async Task<IEnumerable<Animal>> FindAllAsync()
        {
            return await _context.Animales
                .Include(a => a.Tipo)
                .Include(a => a.Duenio)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Animal>> FindByConditionAsync(Expression<Func<Animal, bool>> expression)
        {
            return await _context.Animales
                .Include(a => a.Tipo)
                .Include(a => a.Duenio)
                .Where(expression)
                .ToListAsync();
        }
    }
}
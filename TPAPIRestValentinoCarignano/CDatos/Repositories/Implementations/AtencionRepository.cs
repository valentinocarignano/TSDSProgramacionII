using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CDatos.Repositories.Implementations
{
    public class AtencionRepository : Repository<Atencion>, IAtencionRepository
    {
        public AtencionRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Atencion>> FindAllAsync()
        {
            return await _context.Atenciones
                .Include(a => a.Animal)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Atencion>> FindByConditionAsync(Expression<Func<Atencion, bool>> expression)
        {
            return await _context.Atenciones
                .Include(a => a.Animal)
                .Where(expression)
                .ToListAsync();
        }
    }
}

using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entities;

namespace CDatos.Repositories.Implementations
{
    public class TipoRepository : Repository<Tipo>, ITipoRepository
    {
        public TipoRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entities;

namespace CDatos.Repositories.Implementations
{
    public class DuenioRepository : Repository<Duenio>, IDuenioRepository
    {
        public DuenioRepository(AppDbContext context) : base(context)
        {
        }
    }
}

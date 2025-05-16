using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CDatos.Repositories
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        public PersonaRepository(LibreriaContext context) : base(context)
        {
            
        }

        public async Task<List<Persona>> GetAll()
        {
            try
            {
                return await _context.Persona.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
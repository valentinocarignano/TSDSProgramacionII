

using CEntidades.Entidades;

namespace CDatos.Repositories.Contracts
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Task<List<Persona>> GetAll();
    }
}
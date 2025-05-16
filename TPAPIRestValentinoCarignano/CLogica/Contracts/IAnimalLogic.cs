using CEntidades.DTOs.RespuestaDTOs;

namespace CLogica.Contracts
{
    public interface IAnimalLogic
    {
        Task<List<AnimalDTO>> ObtenerAnimales();
        Task<AnimalDTO> ObtenerAnimalID(int id);
        Task<AnimalDTO> AgregarAnimal(string nombre, int idTipo, string raza, string sexo, DateTime fechaNacimiento, int? idDuenio);
        Task<AnimalDTO> ModificarAnimal(int id, string nombre, string sexo, DateTime fechaNacimiento, int? idDuenio);
        Task<bool> EliminarAnimal(int id);
    }
}
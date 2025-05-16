using CEntidades.DTOs.RespuestaDTOs;

namespace CLogica.Contracts
{
    public interface IDuenioLogic
    {
        Task<List<DuenioDTO>> ObtenerDuenios();
        Task<DuenioDTO> ObtenerDuenioID(int id);
        Task<DuenioDTO> ObtenerDuenioDNI(int dni);
        Task<DuenioDTO> AgregarDuenio(int dni, string nombre, string apellido);
        Task<DuenioDTO> ModificarDuenio(int id, string nombre, string apellido);
        Task<bool> EliminarDuenioID(int id);
        Task<bool> EliminarDuenioDNI(int dni);
    }
}
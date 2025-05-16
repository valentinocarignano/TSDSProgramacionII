using CEntidades.DTOs.RespuestaDTOs;

namespace CLogica.Contracts
{
    public interface ITipoLogic
    {
        Task<List<TipoDTO>> ObtenerTipos();
        Task<TipoDTO> ObtenerTiposID(int id);
        Task<TipoDTO> ObtenerTiposDescripcion(string descripcion);
        Task<TipoDTO> AgregarTipo(string descripcion);
        Task<TipoDTO> ModificarTipo(int id, string descripcion);
        Task<bool> EliminarTipo(int id);
    }
}
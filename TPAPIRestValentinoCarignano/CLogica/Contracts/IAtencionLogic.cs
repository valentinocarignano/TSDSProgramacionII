using CEntidades.DTOs.RespuestaDTOs;

namespace CLogica.Contracts
{
    public interface IAtencionLogic
    {
        Task<List<AtencionDTO>> ObtenerAtenciones();
        Task<AtencionDTO> ObtenerAtencionID(int id);
        Task<List<AtencionDTO>> ObtenerAtencionesMedicamento(string medicamento);
        Task<List<AtencionDTO>> ObtenerAtencionesFechas(DateTime fechaDesde, DateTime fechaHasta);
        Task<AtencionDTO> AgregarAtencion(string motivo, string tratamiento, string? medicamento, DateTime? fecha, int idAnimal);
        Task<AtencionDTO> ModificarAtencion(int id, string motivo, string tratamiento, string? medicamento, DateTime? fecha);
        Task<bool> EliminarAtencion(int id);
    }
}
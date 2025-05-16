using CEntidades.DTOs.CrearDTOs;
using CEntidades.DTOs.ModificarDTOs;
using CEntidades.DTOs.RespuestaDTOs;
using CLogica.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAPI.Controllers
{
    [Route("api/atenciones")]
    [ApiController]
    public class AtencionController : ControllerBase
    {
        private readonly IAtencionLogic _atencionLogic;

        public AtencionController(IAtencionLogic atencionLogic)
        {
            _atencionLogic = atencionLogic;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<AtencionDTO> atencionDTO = await _atencionLogic.ObtenerAtenciones();

            return Ok(atencionDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            AtencionDTO atencionDTO = await _atencionLogic.ObtenerAtencionID(id);

            if (atencionDTO == null)
            {
                return NotFound();
            }

            return Ok(atencionDTO);
        }

        [HttpGet("medicamento/{medicamento}")]
        public async Task<IActionResult> ObtenerPorMedicamento(string medicamento)
        {
            List<AtencionDTO> atencionDTO = await _atencionLogic.ObtenerAtencionesMedicamento(medicamento);

            return Ok(atencionDTO);
        }

        [HttpGet("fechas/{fechaDesde}/{fechaHasta}")]
        public async Task<IActionResult> ObtenerPorFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<AtencionDTO> atencionDTO = await _atencionLogic.ObtenerAtencionesFechas(fechaDesde, fechaHasta);

            return Ok(atencionDTO);
        }

        [HttpGet("solo-medicamentos")]
        public async Task<IActionResult> ObtenerSoloMedicamentos()
        {
            List<AtencionDTO> atencionDTO = await _atencionLogic.ObtenerAtenciones();

            List<string?> medicamentos = atencionDTO.Select(a => a.Medicamentos).ToList();

            return Ok(medicamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearAtencionDTO crearAtencionDTO)
        {
            AtencionDTO atencionDTO = await _atencionLogic.AgregarAtencion(crearAtencionDTO.Motivo, crearAtencionDTO.Tratamiento, crearAtencionDTO.Medicamentos, crearAtencionDTO.Fecha, crearAtencionDTO.AnimalId);

            return Ok(atencionDTO);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] ModificarAtencionDTO modificarAtencionDTO)
        {
            AtencionDTO atencionDTO = await _atencionLogic.ModificarAtencion(id, modificarAtencionDTO.Motivo, modificarAtencionDTO.Tratamiento, modificarAtencionDTO.Medicamentos, modificarAtencionDTO.Fecha);
            if (atencionDTO == null)
            {
                return NotFound();
            }

            return Ok(atencionDTO);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _atencionLogic.EliminarAtencion(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
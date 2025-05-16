using CEntidades.DTOs.CrearDTOs;
using CEntidades.DTOs.ModificarDTOs;
using CEntidades.DTOs.RespuestaDTOs;
using CLogica.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAPI.Controllers
{
    [Route("api/duenios")]
    [ApiController]
    public class DuenioController : ControllerBase
    {
        private readonly IDuenioLogic _duenioLogic;

        public DuenioController(IDuenioLogic duenioLogic)
        {
            _duenioLogic = duenioLogic;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<DuenioDTO> duenioDTO = await _duenioLogic.ObtenerDuenios();

            return Ok(duenioDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            DuenioDTO duenioDTO = await _duenioLogic.ObtenerDuenioID(id);

            if (duenioDTO == null)
            {
                return NotFound();
            }

            return Ok(duenioDTO);
        }

        [HttpGet("dni/{dni}")]
        public async Task<IActionResult> ObtenerPorDNI(int dni)
        {
            DuenioDTO duenioDTO = await _duenioLogic.ObtenerDuenioDNI(dni);

            if (duenioDTO == null)
            {
                return NotFound();
            }

            return Ok(duenioDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearDuenioDTO crearDuenioDTO)
        {
            DuenioDTO duenioDto = await _duenioLogic.AgregarDuenio(
                crearDuenioDTO.DNI,
                crearDuenioDTO.Nombre,
                crearDuenioDTO.Apellido);

            return Ok(duenioDto);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] ModificarDuenioDTO modificarDuenioDTO)
        {
            DuenioDTO duenioDTO = await _duenioLogic.ModificarDuenio(
                id,
                modificarDuenioDTO.Nombre,
                modificarDuenioDTO.Apellido);

            if (duenioDTO == null)
            {
                return NotFound();
            }

            return Ok(duenioDTO);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> EliminarPorID(int id)
        {
            bool eliminado = await _duenioLogic.EliminarDuenioID(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("dni/{dni}")]
        public async Task<IActionResult> EliminarPorDNI(int dni)
        {
            bool eliminado = await _duenioLogic.EliminarDuenioDNI(dni);

            if (!eliminado)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
using CEntidades.DTOs.CrearDTOs;
using CEntidades.DTOs.ModificarDTOs;
using CEntidades.DTOs.RespuestaDTOs;
using CLogica.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAPI.Controllers
{
    [Route("api/tipos")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoLogic _tipoLogic;
        
        public TipoController(ITipoLogic tipoLogic)
        {
            _tipoLogic = tipoLogic;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<TipoDTO> tipoDTO = await _tipoLogic.ObtenerTipos();

            return Ok(tipoDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            TipoDTO tipoDTO = await _tipoLogic.ObtenerTiposID(id);

            if(tipoDTO == null)
            {
                return NotFound();
            }

            return Ok(tipoDTO);
        }

        [HttpGet("descripcion/{descripcion}")]
        public async Task<IActionResult> ObtenerPorDescripcion(string descripcion)
        {
            TipoDTO tipoDTO = await _tipoLogic.ObtenerTiposDescripcion(descripcion);

            if (tipoDTO == null)
            {
                return NotFound();
            }

            return Ok(tipoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearTipoDTO crearTipoDTO)
        {
            TipoDTO tipoDTO = await _tipoLogic.AgregarTipo(crearTipoDTO.Descripcion);

            return Ok(tipoDTO);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] ModificarTipoDTO modificarTipoDTO)
        {
            TipoDTO tipoDTO = await _tipoLogic.ModificarTipo(id, modificarTipoDTO.Descripcion);

            if(tipoDTO == null)
            {
                return NotFound();
            }

            return Ok(tipoDTO);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _tipoLogic.EliminarTipo(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
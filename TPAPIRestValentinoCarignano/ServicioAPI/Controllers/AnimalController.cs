using CEntidades.DTOs.CrearDTOs;
using CEntidades.DTOs.ModificarDTOs;
using CEntidades.DTOs.RespuestaDTOs;
using CLogica.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAPI.Controllers
{
    [Route("api/animales")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalLogic _animalLogic;

        public AnimalController(IAnimalLogic animalLogic)
        {
            _animalLogic = animalLogic;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            List<AnimalDTO> animalDTO = await _animalLogic.ObtenerAnimales();

            return Ok(animalDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            AnimalDTO animalDTO = await _animalLogic.ObtenerAnimalID(id);

            if (animalDTO == null)
            {
                return NotFound();
            }

            return Ok(animalDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearAnimalDTO crearAnimalDTO)
        {
            AnimalDTO animalDTO = await _animalLogic.AgregarAnimal(crearAnimalDTO.Nombre, crearAnimalDTO.IDTipo, crearAnimalDTO.Raza, crearAnimalDTO.Sexo, crearAnimalDTO.FechaNacimineto, crearAnimalDTO.IDDuenio);

            return Ok(animalDTO);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] ModificarAnimalDTO modificarAnimalDTO)
        {
            AnimalDTO animalDTO = await _animalLogic.ModificarAnimal(id, modificarAnimalDTO.Nombre, modificarAnimalDTO.Sexo, modificarAnimalDTO.FechaNacimineto, modificarAnimalDTO.IDDuenio);

            if (animalDTO == null)
            {
                return NotFound();
            }

            return Ok(animalDTO);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _animalLogic.EliminarAnimal(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
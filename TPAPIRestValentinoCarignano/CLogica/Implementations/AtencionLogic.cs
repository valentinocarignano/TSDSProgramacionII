using CDatos.Repositories.Contracts;
using CEntidades.DTOs.RespuestaDTOs;
using CEntidades.Entities;
using CLogica.Contracts;

namespace CLogica.Implementations
{
    public class AtencionLogic : IAtencionLogic
    {
        private readonly IAtencionRepository _atencionRepository;
        private readonly IAnimalRepository _animalRepository;

        public AtencionLogic(IAtencionRepository atencionRepository, IAnimalRepository animalRepository)
        {
            _atencionRepository = atencionRepository;
            _animalRepository = animalRepository;
        }

        public async Task<List<AtencionDTO>> ObtenerAtenciones()
        {
            try
            {
                List<Atencion> listaAtenciones = (await _atencionRepository.FindAllAsync()).ToList();

                if (listaAtenciones == null)
                {
                    return null;
                }

                List<AtencionDTO> listaAtencionesDTO = listaAtenciones.Select(t => new AtencionDTO
                {
                    ID = t.ID,
                    Motivo = t.Motivo,
                    Tratamiento = t.Tratamiento,
                    Medicamentos = t.Medicamentos,
                    Fecha = t.Fecha,
                    AnimalId = t.Animal.ID
                }).ToList();

                return listaAtencionesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<AtencionDTO> ObtenerAtencionID(int id)
        {
            try
            {
                Atencion? atencion = (await _atencionRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (atencion == null)
                {
                    return null;
                }

                AtencionDTO atencionDTO = new AtencionDTO
                {
                    ID = atencion.ID,
                    Motivo = atencion.Motivo,
                    Tratamiento = atencion.Tratamiento,
                    Medicamentos = atencion.Medicamentos,
                    Fecha = atencion.Fecha,
                    AnimalId = atencion.Animal.ID
                };

                return atencionDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<List<AtencionDTO>> ObtenerAtencionesMedicamento(string medicamento)
        {
            try
            {
                List<Atencion> listaAtenciones = (await _atencionRepository.FindByConditionAsync(t => t.Medicamentos == medicamento)).ToList();

                if (listaAtenciones == null)
                {
                    return null;
                }

                List<AtencionDTO> listaAtencionesDTO = listaAtenciones.Select(t => new AtencionDTO
                {
                    ID = t.ID,
                    Motivo = t.Motivo,
                    Tratamiento = t.Tratamiento,
                    Medicamentos = t.Medicamentos,
                    Fecha = t.Fecha,
                    AnimalId = t.Animal.ID
                }).ToList();

                return listaAtencionesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<List<AtencionDTO>> ObtenerAtencionesFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                List<Atencion> listaAtenciones = (await _atencionRepository.FindByConditionAsync(t => t.Fecha >= fechaDesde && t.Fecha <= fechaHasta)).ToList();

                if (listaAtenciones == null)
                {
                    return null;
                }

                List<AtencionDTO> listaAtencionesDTO = listaAtenciones.Select(t => new AtencionDTO
                {
                    ID = t.ID,
                    Motivo = t.Motivo,
                    Tratamiento = t.Tratamiento,
                    Medicamentos = t.Medicamentos,
                    Fecha = t.Fecha,
                    AnimalId = t.Animal.ID
                }).ToList();

                return listaAtencionesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<AtencionDTO> AgregarAtencion(string motivo, string tratamiento, string? medicamento, DateTime? fecha, int idAnimal)
        {
            try
            {
                Animal? animalExistente = (await _animalRepository.FindByConditionAsync(t => t.ID == idAnimal)).FirstOrDefault();

                if(animalExistente == null)
                {
                    throw new KeyNotFoundException($"No se encontró un animal con el ID {idAnimal}.");
                }

                if (fecha < DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("La fecha no puede ser anterior a la del dia de hoy.");
                }

                Atencion nuevaAtencion = new Atencion
                {
                    Motivo = motivo,
                    Tratamiento = tratamiento,
                    Fecha = fecha,
                    Medicamentos = medicamento,
                    Animal = animalExistente
                };

                await _atencionRepository.AddAsync(nuevaAtencion);
                await _atencionRepository.SaveAsync();

                AtencionDTO nuevaAtencionDTO = new AtencionDTO
                {
                    ID = nuevaAtencion.ID,
                    Motivo = nuevaAtencion.Motivo,
                    Tratamiento = nuevaAtencion.Tratamiento,
                    Fecha = nuevaAtencion.Fecha,
                    Medicamentos = nuevaAtencion.Medicamentos,
                    AnimalId = nuevaAtencion.Animal.ID
                };

                return nuevaAtencionDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<AtencionDTO> ModificarAtencion(int id, string motivo, string tratamiento, string? medicamento, DateTime? fecha)
        {
            try
            {
                Atencion? atencionExistente = (await _atencionRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (atencionExistente == null)
                {
                    return null;
                }

                atencionExistente.Motivo = motivo;
                atencionExistente.Tratamiento = tratamiento;
                atencionExistente.Medicamentos = medicamento;

                TimeSpan intervaloFechas = DateTime.Now - atencionExistente.CreatedDate;
                if (fecha is not null && fecha < DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("La fecha no puede ser anterior a la del dia de hoy.");
                }
                else if(fecha is not null && intervaloFechas.Days > 30 )
                {
                    throw new ArgumentOutOfRangeException("No se puede agregar una fecha pasados los 30 dias de la creacion del registro.");
                }

                atencionExistente.Fecha = fecha;

                _atencionRepository.Update(atencionExistente);
                await _atencionRepository.SaveAsync();

                AtencionDTO atencionExistenteDTO = new AtencionDTO
                {
                    ID = atencionExistente.ID,
                    Motivo = atencionExistente.Motivo,
                    Tratamiento = atencionExistente.Tratamiento,
                    Fecha = atencionExistente.Fecha,
                    Medicamentos = atencionExistente.Medicamentos,
                    AnimalId = atencionExistente.Animal.ID
                };

                return atencionExistenteDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<bool> EliminarAtencion(int id)
        {
            try
            {
                Atencion? atencionExistente = (await _atencionRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (atencionExistente == null)
                {
                    return false;
                }

                _atencionRepository.Remove(atencionExistente);
                await _atencionRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}

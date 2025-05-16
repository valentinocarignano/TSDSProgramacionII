using CDatos.Repositories.Contracts;
using CEntidades.DTOs.RespuestaDTOs;
using CEntidades.Entities;
using CLogica.Contracts;

namespace CLogica.Implementations
{
    public class DuenioLogic : IDuenioLogic
    {
        private readonly IDuenioRepository _duenioRepository;

        public DuenioLogic(IDuenioRepository duenioRepository)
        {
            _duenioRepository = duenioRepository;
        }

        public async Task<List<DuenioDTO>> ObtenerDuenios()
        {
            try
            {
                List<Duenio> listaDuenios = (await _duenioRepository.FindAllAsync()).ToList();

                if (listaDuenios == null)
                {
                    return null;
                }

                List<DuenioDTO> listaDueniosDTO = listaDuenios.Select(t => new DuenioDTO
                {
                    ID = t.ID,
                    DNI = t.DNI,
                    Nombre = t.Nombre,
                    Apellido = t.Apellido,
                }).ToList();

                return listaDueniosDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<DuenioDTO> ObtenerDuenioID(int id)
        {
            try
            {
                Duenio? duenio = (await _duenioRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (duenio == null)
                {
                    return null;
                }

                DuenioDTO duenioDTO = new DuenioDTO
                {
                    ID = duenio.ID,
                    DNI = duenio.DNI,
                    Nombre = duenio.Nombre,
                    Apellido = duenio.Apellido,
                };

                return duenioDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<DuenioDTO> ObtenerDuenioDNI(int dni)
        {
            try
            {
                Duenio? duenio = (await _duenioRepository.FindByConditionAsync(t => t.DNI == dni)).FirstOrDefault();

                if (duenio == null)
                {
                    return null;
                }

                DuenioDTO duenioDTO = new DuenioDTO
                {
                    ID = duenio.ID,
                    DNI = duenio.DNI,
                    Nombre = duenio.Nombre,
                    Apellido = duenio.Apellido,
                };

                return duenioDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<DuenioDTO> AgregarDuenio(int dni, string nombre, string apellido)
        {
            try
            {
                Duenio nuevoDuenio = new Duenio
                {
                    DNI = dni,
                    Nombre = nombre,
                    Apellido = apellido
                };

                await _duenioRepository.AddAsync(nuevoDuenio);
                await _duenioRepository.SaveAsync();

                DuenioDTO nuevoDuenioDTO = new DuenioDTO
                {
                    ID = nuevoDuenio.ID,
                    DNI = nuevoDuenio.DNI,
                    Nombre = nuevoDuenio.Nombre,
                    Apellido = nuevoDuenio.Apellido
                };

                return nuevoDuenioDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<DuenioDTO> ModificarDuenio(int id, string nombre, string apellido)
        {
            try
            {
                Duenio? duenioExistente = (await _duenioRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (duenioExistente == null)
                {
                    return null;
                }

                duenioExistente.Nombre = nombre;
                duenioExistente.Apellido = apellido;

                _duenioRepository.Update(duenioExistente);
                await _duenioRepository.SaveAsync();

                DuenioDTO tipoExistenteDTO = new DuenioDTO
                {
                    ID = duenioExistente.ID,
                    DNI = duenioExistente.DNI,
                    Nombre = duenioExistente.Nombre,
                    Apellido = duenioExistente.Apellido
                };

                return tipoExistenteDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<bool> EliminarDuenioID(int id)
        {
            try
            {
                Duenio? duenioExistente = (await _duenioRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (duenioExistente == null)
                {
                    return false;
                }

                _duenioRepository.Remove(duenioExistente);
                await _duenioRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<bool> EliminarDuenioDNI(int dni)
        {
            try
            {
                Duenio? duenioExistente = (await _duenioRepository.FindByConditionAsync(t => t.DNI == dni)).FirstOrDefault();

                if (duenioExistente == null)
                {
                    return false;
                }

                _duenioRepository.Remove(duenioExistente);
                await _duenioRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}

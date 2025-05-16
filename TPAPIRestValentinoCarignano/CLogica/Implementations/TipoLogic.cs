using CDatos.Repositories.Contracts;
using CEntidades.DTOs.RespuestaDTOs;
using CEntidades.Entities;
using CLogica.Contracts;

namespace CLogica.Implementations
{
    public class TipoLogic : ITipoLogic
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoLogic(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        public async Task<List<TipoDTO>> ObtenerTipos()
        {
            try
            {
                List<Tipo> listaTipos = (await _tipoRepository.FindAllAsync()).ToList();

                if (listaTipos == null)
                {
                    return null;
                }

                List<TipoDTO> listaTiposDTO = listaTipos.Select(t => new TipoDTO
                {
                    ID = t.ID,
                    Descripcion = t.Descripcion
                }).ToList();

                return listaTiposDTO;
                }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<TipoDTO> ObtenerTiposID(int id)
        {
            try
            {
                Tipo? tipo = (await _tipoRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (tipo == null)
                {
                    return null;
                }

                TipoDTO tipoDTO = new TipoDTO
                {
                    ID = tipo.ID,
                    Descripcion = tipo.Descripcion
                };

                return tipoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<TipoDTO> ObtenerTiposDescripcion(string descripcion)
        {
            try
            {
                Tipo? tipo = (await _tipoRepository.FindByConditionAsync(t => t.Descripcion == descripcion)).FirstOrDefault();

                if (tipo == null)
                {
                    return null;
                }

                TipoDTO tipoDTO = new TipoDTO
                {
                    ID = tipo.ID,
                    Descripcion = tipo.Descripcion
                };

                return tipoDTO;
                }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<TipoDTO> AgregarTipo(string descripcion)
        {
            try
            {
                Tipo nuevoTipo = new Tipo
                {
                    Descripcion = descripcion
                };

                await _tipoRepository.AddAsync(nuevoTipo);
                await _tipoRepository.SaveAsync();

                TipoDTO nuevoTipoDTO = new TipoDTO
                {
                    ID = nuevoTipo.ID,
                    Descripcion = nuevoTipo.Descripcion
                };

                return nuevoTipoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<TipoDTO> ModificarTipo(int id, string descripcion)
        {
            try
            {
                Tipo? tipoExistente = (await _tipoRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (tipoExistente == null)
                {
                    return null;
                }

                tipoExistente.Descripcion = descripcion;

                _tipoRepository.Update(tipoExistente);
                await _tipoRepository.SaveAsync();

                TipoDTO tipoExistenteDTO = new TipoDTO
                {
                    ID = tipoExistente.ID,
                    Descripcion = tipoExistente.Descripcion
                };

                return tipoExistenteDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<bool> EliminarTipo(int id)
        {
            try
            {
                Tipo? tipoExistente = (await _tipoRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (tipoExistente == null)
                {
                    return false;
                }

                _tipoRepository.Remove(tipoExistente);
                await _tipoRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}
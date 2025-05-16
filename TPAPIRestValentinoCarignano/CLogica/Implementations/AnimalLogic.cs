using CDatos.Repositories.Contracts;
using CEntidades.DTOs.RespuestaDTOs;
using CEntidades.Entities;
using CLogica.Contracts;

namespace CLogica.Implementations
{
    public class AnimalLogic : IAnimalLogic
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ITipoRepository _tipoRepository;
        private readonly IDuenioRepository _duenioRepository;

        public AnimalLogic(IAnimalRepository animalRepository, ITipoRepository tipoRepository, IDuenioRepository duenioRepository)
        {
            _animalRepository = animalRepository;
            _tipoRepository = tipoRepository;
            _duenioRepository = duenioRepository;
        }

        public async Task<List<AnimalDTO>> ObtenerAnimales()
        {
            try
            {
                List<Animal> listaAnimales = (await _animalRepository.FindAllAsync()).ToList();

                if (listaAnimales == null)
                {
                    return null;
                }

                List<AnimalDTO> listaAnimalesDTO = listaAnimales.Select(t => new AnimalDTO
                {
                    ID = t.ID,
                    Nombre = t.Nombre,
                    DescripcionTipo = t.Tipo.Descripcion,
                    Raza = t.Raza,
                    Sexo = t.Sexo,
                    FechaNacimineto = t.FechaNacimiento,
                    DNIDuenio = t.Duenio?.DNI ?? 0
                }).ToList();

                return listaAnimalesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<AnimalDTO> ObtenerAnimalID(int id)
        {
            try
            {
                Animal? animal = (await _animalRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (animal == null)
                {
                    return null;
                }

                AnimalDTO duenioDTO = new AnimalDTO
                {
                    ID = animal.ID,
                    Nombre = animal.Nombre,
                    DescripcionTipo = animal.Tipo.Descripcion,
                    Raza = animal.Raza,
                    Sexo = animal.Sexo,
                    FechaNacimineto = animal.FechaNacimiento,
                    DNIDuenio = animal.Duenio?.DNI
                };

                return duenioDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<AnimalDTO> AgregarAnimal(string nombre, int idTipo, string raza, string sexo, DateTime fechaNacimiento, int? idDuenio)
        {
            try
            {
                Tipo? tipoExistente = (await _tipoRepository.FindByConditionAsync(t => t.ID == idTipo)).FirstOrDefault();
                Duenio? duenioExistente = (await _duenioRepository.FindByConditionAsync(t => t.ID == idDuenio)).FirstOrDefault();


                Animal nuevoAnimal = new Animal
                {
                    Nombre = nombre,
                    Tipo = tipoExistente,
                    Raza = raza,
                    Sexo = sexo,
                    FechaNacimiento = fechaNacimiento,
                    Duenio = duenioExistente
                };

                await _animalRepository.AddAsync(nuevoAnimal);
                await _animalRepository.SaveAsync();

                AnimalDTO nuevoAnimalDTO = new AnimalDTO
                {
                    ID = nuevoAnimal.ID,
                    Nombre = nuevoAnimal.Nombre,
                    DescripcionTipo = nuevoAnimal.Tipo.Descripcion,
                    Raza = nuevoAnimal.Raza,
                    Sexo = nuevoAnimal.Sexo,
                    FechaNacimineto = nuevoAnimal.FechaNacimiento,
                    DNIDuenio = nuevoAnimal.Duenio?.DNI
                };

                return nuevoAnimalDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<AnimalDTO> ModificarAnimal(int id, string nombre, string sexo, DateTime fechaNacimiento, int? idDuenio)
        {
            try
            {
                Animal? animalExistente = (await _animalRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (animalExistente == null)
                {
                    return null;
                }

                Duenio? duenioExistente = (await _duenioRepository.FindByConditionAsync(t => t.ID == idDuenio)).FirstOrDefault();

                animalExistente.Nombre = nombre;
                animalExistente.Sexo = sexo;
                animalExistente.FechaNacimiento = fechaNacimiento;
                animalExistente.Duenio = duenioExistente;

                _animalRepository.Update(animalExistente);
                await _animalRepository.SaveAsync();

                AnimalDTO animalExistenteDTO = new AnimalDTO
                {
                    ID = animalExistente.ID,
                    Nombre = animalExistente.Nombre,
                    DescripcionTipo = animalExistente.Tipo.Descripcion,
                    Raza = animalExistente.Raza,
                    Sexo = animalExistente.Sexo,
                    FechaNacimineto = animalExistente.FechaNacimiento,
                    DNIDuenio = animalExistente.Duenio?.DNI
                };

                return animalExistenteDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
        public async Task<bool> EliminarAnimal(int id)
        {
            try
            {
                Animal? animalExistente = (await _animalRepository.FindByConditionAsync(t => t.ID == id)).FirstOrDefault();

                if (animalExistente == null)
                {
                    return false;
                }

                _animalRepository.Remove(animalExistente);
                await _animalRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        //DUENIO
        static async Task<Uri> CrearDuenioAsync(ConsolaDuenioDTO duenioDTO)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/duenios", duenioDTO);
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}:\n{error}");
                return null;
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        //ANIMAL
        static void ShowAnimal(ConsolaAnimalDTO animal)
        {
            Console.WriteLine($"ID: {animal.ID}\tNombre: " +
                $"{animal.Nombre}\tRaza: {animal.Raza}\tSexo: {animal.Sexo}\tDueño: {animal.DNIDuenio}");
        }

        static void ShowAnimales(List<ConsolaAnimalDTO> animales)
        {
            foreach(ConsolaAnimalDTO animal in animales)
            {
                Console.WriteLine($"ID: {animal.ID}\tNombre: " +
                $"{animal.Nombre}\tRaza: {animal.Raza}\tSexo: {animal.Sexo}\tDueño: {animal.DNIDuenio}");
            }
        }

        static async Task<List<ConsolaAnimalDTO>> GetAnimalesAsync(string path)
        {
            List<ConsolaAnimalDTO> animales = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                animales = await response.Content.ReadAsAsync<List<ConsolaAnimalDTO>>();
            }
            return animales;
        }

        static async Task<Uri> CrearAnimalAsync(ConsolaCrearAnimalDTO animalDTO)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/animales/", animalDTO);
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}:\n{error}");
                return null;
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<ConsolaModificarAnimalDTO> UpdateAnimalAsync(int id, ConsolaModificarAnimalDTO modAnimal)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/animales/id/{id}", modAnimal);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            modAnimal = await response.Content.ReadAsAsync<ConsolaModificarAnimalDTO>();
            return modAnimal;
        }

        static async Task<HttpStatusCode> DeleteAnimalAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/animales/id/{id}");
            return response.StatusCode;
        }

        //ATENCION
        static async Task<Uri> CrearAtencionAsync(ConsolaCrearAtencionDTO atencionDTO)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/atenciones/", atencionDTO);
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}:\n{error}");
                return null;
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        //MEDICAMENTOS
        static void ShowMedicamentos(List<string> medicamentos)
        {
            Console.WriteLine("Lista de Medicamentos: ");
            foreach (var medicamento in medicamentos)
            {
                Console.WriteLine(medicamento);
            }
        }

        static async Task<List<string>> GetMedicamentosAsync(string path)
        {
            List<string> medicamentos = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                medicamentos = await response.Content.ReadAsAsync<List<string>>();
            }
            return medicamentos;
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7167/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine("SISTEMA DE GESTION VETERINARIA\n");
            Console.WriteLine("QUE ACCION QUIERE LLEVAR A CABO?");

            Console.WriteLine("1 - Crear Dueño\n2 - Consultar Animales\n3 - Crear Animales\n4 - Modificar Animales\n" +
                              "5 - Eliminar Animales\n6 - Crear Atencion\n7 - Consultar Medicamentos\n");

            Console.WriteLine("Ingrese numero:");
            if (!Int32.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("El numero ingresado no es valido, vuelva a ejecutar y pruebe otra vez.");
            }

            switch (numero)
            {
                case 1:

                    Console.WriteLine("Ingrese DNI:");
                    if (!Int32.TryParse(Console.ReadLine(), out int dni))
                    {
                        Console.WriteLine("El DNI ingresado no es valido, vuelva a ejecutar y pruebe otra vez.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Ingrese Nombre:");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese Apellido:");
                    string apellido = Console.ReadLine();

                    ConsolaDuenioDTO duenioDTO = new ConsolaDuenioDTO
                    {
                        DNI = dni,
                        Nombre = nombre,
                        Apellido = apellido
                    };

                    var url = await CrearDuenioAsync(duenioDTO);
                    Console.WriteLine($"Created at {url}");
                    Console.ReadKey();

                    break;

                case 2:

                    List<ConsolaAnimalDTO> animales = await GetAnimalesAsync("/api/animales");
                    ShowAnimales(animales);
                    Console.ReadKey();

                    break;

                case 3:
                    Console.WriteLine("Ingrese Nombre:");
                    string nombreAnimal = Console.ReadLine();

                    Console.WriteLine("Ingrese Fecha Nacimiento (ej: 25/12/2020):");
                    string input = Console.ReadLine();
                    if (!DateTime.TryParse(input, out DateTime fechaNacAnimal))
                    {
                        Console.WriteLine("Fecha inválida. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Ingrese ID Tipo:");
                    if (!Int32.TryParse(Console.ReadLine(), out int idTipo))
                    {
                        Console.WriteLine("El ID del Tipo no es válido. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Ingrese ID DUENIO (deje vacío si no tiene):");
                    string duenioInput = Console.ReadLine();
                    int? idDuenio = null;

                    if (!string.IsNullOrWhiteSpace(duenioInput))
                    {
                        if (Int32.TryParse(duenioInput, out int temp))
                        {
                            idDuenio = temp;
                        }
                        else
                        {
                            Console.WriteLine("El ID del Duenio no es válido. Intente de nuevo.");
                            Console.ReadKey();
                            break;
                        }
                    }

                    Console.WriteLine("Ingrese Raza:");
                    string raza = Console.ReadLine();

                    Console.WriteLine("Ingrese Sexo:");
                    string sexo = Console.ReadLine();

                    ConsolaCrearAnimalDTO crearanimalDTO = new ConsolaCrearAnimalDTO
                    {
                        Nombre = nombreAnimal,
                        FechaNacimineto = fechaNacAnimal,
                        IDTipo = idTipo,
                        IDDuenio = idDuenio,
                        Raza = raza,
                        Sexo = sexo
                    };

                    var urlAnimal = await CrearAnimalAsync(crearanimalDTO);
                    Console.WriteLine($"Created at {urlAnimal}");
                    Console.ReadKey();

                    break;

                case 4:
                    Console.WriteLine("Ingrese ID del Animal a modificar:");
                    if (!Int32.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("El ID del animal no es válido. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Ingrese Nombre:");
                    string nombreAnimalmod = Console.ReadLine();

                    Console.WriteLine("Ingrese Fecha Nacimiento (ej: 25/12/2020):");
                    string input1 = Console.ReadLine();
                    if (!DateTime.TryParse(input1, out DateTime fechaNacAnimalmod))
                    {
                        Console.WriteLine("Fecha inválida. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Ingrese ID DUENIO (deje vacío si no tiene):");
                    string duenioInputmod = Console.ReadLine();
                    int? idDueniomod = null;

                    if (!string.IsNullOrWhiteSpace(duenioInputmod))
                    {
                        if (Int32.TryParse(duenioInputmod, out int temp))
                        {
                            idDueniomod = temp;
                        }
                        else
                        {
                            Console.WriteLine("El ID del Duenio no es válido. Intente de nuevo.");
                            Console.ReadKey();
                            break;
                        }
                    }

                    Console.WriteLine("Ingrese Sexo:");
                    string sexomod = Console.ReadLine();

                    ConsolaModificarAnimalDTO updateAnimal = new ConsolaModificarAnimalDTO
                    {
                        Nombre = nombreAnimalmod,
                        FechaNacimineto = fechaNacAnimalmod,
                        IDDuenio = idDueniomod,
                        Sexo = sexomod
                    };

                    await UpdateAnimalAsync(id, updateAnimal);
                    Console.ReadKey();

                    break;

                case 5:
                    Console.WriteLine("Ingrese ID del Animal a eliminar:");
                    if (!Int32.TryParse(Console.ReadLine(), out int iddelete))
                    {
                        Console.WriteLine("El ID del animal no es válido. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }

                    var statusCode = await DeleteAnimalAsync(iddelete);
                    Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
                    Console.ReadKey();
                    break;

                case 6:
                    Console.WriteLine("Ingrese Motivo:");
                    string motivo = Console.ReadLine();

                    Console.WriteLine("Ingrese Tratamiento:");
                    string tratamiento = Console.ReadLine();

                    Console.WriteLine("Ingrese Medicamentos:");
                    string medicamentos = Console.ReadLine();

                    Console.WriteLine("Ingrese Fecha Atencion (ej: 25/12/2020):");
                    string fecha = Console.ReadLine();
                    if (!DateTime.TryParse(fecha, out DateTime fechaParse))
                    {
                        Console.WriteLine("Fecha inválida. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Ingrese ID Animal:");
                    if (!Int32.TryParse(Console.ReadLine(), out int idAnimal))
                    {
                        Console.WriteLine("El ID del Animal no es válido. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }

                    ConsolaCrearAtencionDTO crearAtencionDTO = new ConsolaCrearAtencionDTO
                    {
                        Motivo = motivo,
                        Tratamiento = tratamiento,
                        Medicamentos = medicamentos,
                        Fecha = fechaParse,
                        AnimalId = idAnimal
                    };

                    var urlAtencion = await CrearAtencionAsync(crearAtencionDTO);
                    Console.WriteLine($"Created at {urlAtencion}");
                    Console.ReadKey();

                    break;

                case 7:
                    List<string> medicamentoslista = await GetMedicamentosAsync("/api/atenciones/solo-medicamentos");
                    ShowMedicamentos(medicamentoslista);
                    Console.ReadKey();

                    break;

                default:
                    Console.WriteLine($"Ningun numero coincide con el ingresado.");
                    Console.ReadKey();

                    break;
            }
        } 
    }
}
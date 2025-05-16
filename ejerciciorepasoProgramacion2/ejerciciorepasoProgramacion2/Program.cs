using System.ComponentModel.DataAnnotations;

#region EJERCICIO 1
/*Console.WriteLine("INICIO DEL PROGRAMA");
Console.WriteLine("CREANDO PRODUCTOS");

Tamanio tamanioChico = new Tamanio()
{
    ID = 1,
    Dimension = "Chico"
};
Tamanio tamanioMediano = new Tamanio()
{
    ID = 2,
    Dimension = "Mediano"
};
Tamanio tamanioGrande = new Tamanio()
{
    ID = 3,
    Dimension = "Grande"
};

TipoProducto fruta = new TipoProducto()
{
    ID = 1,
    Tipo = "Fruta"
};

Producto tomate = new Producto()
{
    ID = 1,
    Descripcion = "Tomate",
    Precio = 1000.60,
    Stock = 500,
    Tamanio = tamanioChico,
    TipoProducto = fruta
};
Console.WriteLine($"PRODUCTO 1: ID {tomate.ID}, DESCRIPCION {tomate.Descripcion}, TAMAÑO {tomate.Tamanio.Dimension}, TIPO {tomate.TipoProducto.Tipo}, PRECIO {tomate.Precio}, STOCK {tomate.Stock}");
Producto sandia = new Producto()
{
    ID = 2,
    Descripcion = "Sandia",
    Precio = 1800.80,
    Stock = 300,
    Tamanio = tamanioGrande,
    TipoProducto = fruta
};
Console.WriteLine($"PRODUCTO 2: ID {sandia.ID}, DESCRIPCION {sandia.Descripcion}, TAMAÑO {sandia.Tamanio.Dimension}, TIPO {sandia.TipoProducto.Tipo}, PRECIO {sandia.Precio}, STOCK {sandia.Stock}");
Producto melon = new Producto()
{
    ID = 3,
    Descripcion = "Melon",
    Precio = 8000.10,
    Stock = 100,
    Tamanio = tamanioMediano,
    TipoProducto = fruta
};
Console.WriteLine($"PRODUCTO 3: ID {melon.ID}, DESCRIPCION {melon.Descripcion}, TAMAÑO {melon.Tamanio.Dimension}, TIPO {melon.TipoProducto.Tipo}, PRECIO {melon.Precio}, STOCK {melon.Stock}");

Cliente cliente = new Cliente()
{
    ID = 1,
    DNI = 46368342,
    Email = "mailfalso@gmail.com",
    Nombre = "Valentino Carignano"
};
Console.WriteLine($"CLIENTE: ID {cliente.ID}, DNI {cliente.DNI}, NOMBRE {cliente.Nombre}, EMAIL {cliente.Email}");

Venta venta = new Venta(cliente);
venta.AgregarProducto(tomate, 2);
venta.AgregarProducto(sandia, 1);
venta.AgregarProducto(melon, 3);

Console.WriteLine(venta);

public class TipoProducto
{
    public int ID { get; set; }
    public string Tipo { get; set; }
}
public class Tamanio
{
    public int ID { get; set; }
    public string Dimension { get; set; }
}
public class Producto
{
    public int ID { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public Tamanio Tamanio { get; set; }
    public TipoProducto TipoProducto { get; set; }

    public bool DescontarStock(int cantidad)
    {
        if (Stock >= cantidad)
        {
            Stock -= cantidad;
            return true;
        }
        return false;
    }
}
public class Cliente
{
    public int ID { get; set; }
    public int DNI { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
}
public class DetalleVenta
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public double Subtotal => Producto.Precio * Cantidad;
}
public class Venta
{
    public Venta(Cliente cliente)
    {
        Fecha = DateTime.Now;
        Cliente = cliente;
        Detalles = new List<DetalleVenta>();
    }

    public int ID { get; set; }
    public DateTime Fecha { get; private set; }
    public Cliente Cliente { get; private set; }
    public List<DetalleVenta> Detalles { get; private set; }
    public double MontoTotal => CalcularTotal();

    public void AgregarProducto(Producto producto, int cantidad)
    {
        if (producto.DescontarStock(cantidad))
        {
            Detalles.Add(new DetalleVenta { Producto = producto, Cantidad = cantidad });
        }
        else
        {
            Console.WriteLine($"No hay suficiente stock para {producto.Descripcion}");
        }
    }

    private double CalcularTotal()
    {
        double total = 0;
        foreach (var detalle in Detalles)
        {
            total += detalle.Subtotal;
        }
        return total;
    }

    public override string ToString()
    {
        string ventaInfo = $"VENTA: FECHA {Fecha}, CLIENTE {Cliente.Nombre}, MONTO TOTAL: {MontoTotal:C}\nDETALLES:\n";
        foreach (var detalle in Detalles)
        {
            ventaInfo += $"- {detalle.Cantidad}x {detalle.Producto.Descripcion} (${detalle.Producto.Precio} c/u) = {detalle.Subtotal:C}\n";
        }
        return ventaInfo;
    }
}*/
#endregion

#region EJERCICIO 2
Console.WriteLine("INICIO DEL SISTEMA DE TURNOS MÉDICOS");

// CREANDO ESPECIALIDADES
EspecialidadMedica cardiologia = new EspecialidadMedica() { ID = 1, Especialidad = "Cardiología" };
EspecialidadMedica pediatria = new EspecialidadMedica() { ID = 2, Especialidad = "Pediatría" };

// CREANDO HORARIOS DE ATENCIÓN
HorarioAtencion horarioManiana = new HorarioAtencion() { ID = 1, Horario = new TimeOnly(9, 0) };
HorarioAtencion horarioTarde = new HorarioAtencion() { ID = 2, Horario = new TimeOnly(15, 30) };

// CREANDO DOCTORES
Doctor doctor1 = new Doctor()
{
    ID = 1,
    Nombre = "Juan",
    Apellido = "Pérez",
    Matricula = 12345,
    Email = "juan.perez@hospital.com",
    Consultorio = "101",
    Especialidad = cardiologia,
    Horario = horarioManiana
};

Doctor doctor2 = new Doctor()
{
    ID = 2,
    Nombre = "Ana",
    Apellido = "Gómez",
    Matricula = 67890,
    Email = "ana.gomez@hospital.com",
    Consultorio = "202",
    Especialidad = pediatria,
    Horario = horarioTarde
};

// CREANDO PACIENTES
Paciente paciente1 = new Paciente()
{
    ID = 1,
    Nombre = "Carlos",
    Apellido = "Fernández",
    FechaNacimiento = new DateOnly(1985, 5, 20),
    Email = "carlos.fernandez@gmail.com",
    Telefono = 1122334455,
    ObraSocial = "OSDE",
    HistorialMedico = new List<string> { "Hipertensión", "Colesterol alto" }
};

Paciente paciente2 = new Paciente()
{
    ID = 2,
    Nombre = "Sofía",
    Apellido = "Martínez",
    FechaNacimiento = new DateOnly(2015, 8, 10),
    Email = "sofia.martinez@gmail.com",
    Telefono = 1199887766,
    ObraSocial = "Swiss Medical",
    HistorialMedico = new List<string> { "Asma infantil" }
};

// CREANDO RECEPCIONISTA
Recepcionista recepcionista1 = new Recepcionista()
{
    ID = 1,
    Nombre = "Laura",
    Apellido = "Rodríguez",
    Usuario = "lrodriguez",
    Password = "admin123",
    Telefono = 1133445566
};

// CREANDO TURNOS MÉDICOS
TurnoMedico turno1 = new TurnoMedico()
{
    ID = 1,
    FechaHora = new DateTime(2025, 4, 5, 9, 0, 0),
    Estado = "Confirmado",
    Duracion = new TimeSpan(0, 30, 0),
    Motivo = "Chequeo anual de presión arterial",
    Paciente = paciente1,
    Doctor = doctor1,
    Recepcionista = recepcionista1
};

TurnoMedico turno2 = new TurnoMedico()
{
    ID = 2,
    FechaHora = new DateTime(2025, 4, 5, 15, 30, 0),
    Estado = "Pendiente",
    Duracion = new TimeSpan(0, 45, 0),
    Motivo = "Consulta por tos persistente",
    Paciente = paciente2,
    Doctor = doctor2,
    Recepcionista = recepcionista1
};

// MOSTRAR INFORMACIÓN DE LOS TURNOS
Console.WriteLine("\nTURNOS ASIGNADOS:");
Console.WriteLine(turno1);
Console.WriteLine(turno2);

//CLASES
public class EspecialidadMedica
{
    public int ID { get; set; }
    public string Especialidad { get; set; }
}

public class HorarioAtencion
{
    public int ID { get; set; }
    public TimeOnly Horario { get; set; }
}

public class Doctor
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Matricula { get; set; }
    public string Email { get; set; }
    public string Consultorio { get; set; }
    public EspecialidadMedica Especialidad { get; set; }
    public HorarioAtencion Horario { get; set; }

    public override string ToString()
    {
        return $"{Nombre} {Apellido} - {Especialidad.Especialidad} (Consultorio {Consultorio})";
    }
}

public class Paciente
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public string Email { get; set; }
    public int Telefono { get; set; }
    public string ObraSocial { get; set; }
    public ICollection<string> HistorialMedico { get; set; }

    public override string ToString()
    {
        return $"{Nombre} {Apellido} - {ObraSocial}";
    }
}

public class Recepcionista
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Usuario { get; set; }
    public string Password { get; set; }
    public int Telefono { get; set; }

    public override string ToString()
    {
        return $"{Nombre} {Apellido} (Usuario: {Usuario})";
    }
}

public class TurnoMedico
{
    public int ID { get; set; }
    public DateTime FechaHora { get; set; }
    public string Estado { get; set; }
    public TimeSpan Duracion { get; set; }
    public string Motivo { get; set; }
    public Paciente Paciente { get; set; }
    public Doctor Doctor { get; set; }
    public Recepcionista Recepcionista { get; set; }

    public override string ToString()
    {
        return $"Turno ID {ID}: {FechaHora} - Estado: {Estado}\n" +
               $"  - Paciente: {Paciente.Nombre} {Paciente.Apellido}\n" +
               $"  - Doctor: {Doctor.Nombre} {Doctor.Apellido} ({Doctor.Especialidad.Especialidad})\n" +
               $"  - Motivo: {Motivo}\n" +
               $"  - Duración: {Duracion.TotalMinutes} minutos\n" +
               $"  - Recepcionista: {Recepcionista.Nombre} {Recepcionista.Apellido}\n";
    }
}
#endregion
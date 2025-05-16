using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class Tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_EMPLEADO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estacion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BicicletasDisponibles = table.Column<int>(type: "int", nullable: false),
                    CapacidadMaxima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ESTACION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MarcaBicicleta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_MARCABICICLETA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoBicicleta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_TIPOBICICLETA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bicicleta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstacionActual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioHora = table.Column<double>(type: "float", nullable: false),
                    IdBicicleta = table.Column<int>(type: "int", nullable: false),
                    IdEstacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_BICICLETA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bicicleta_Estacion_IdEstacion",
                        column: x => x.IdEstacion,
                        principalTable: "Estacion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bicicleta_MarcaBicicleta_IdBicicleta",
                        column: x => x.IdBicicleta,
                        principalTable: "MarcaBicicleta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bicicleta_TipoBicicleta_IdBicicleta",
                        column: x => x.IdBicicleta,
                        principalTable: "TipoBicicleta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alquiler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "time", nullable: false),
                    MontoTotal = table.Column<double>(type: "float", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    IdBicicleta = table.Column<int>(type: "int", nullable: false),
                    IdEstacionOrigen = table.Column<int>(type: "int", nullable: false),
                    IdEstacionDestino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ALQUILER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alquiler_Bicicleta_IdBicicleta",
                        column: x => x.IdBicicleta,
                        principalTable: "Bicicleta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_Empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_Estacion_IdEstacionDestino",
                        column: x => x.IdEstacionDestino,
                        principalTable: "Estacion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alquiler_Estacion_IdEstacionOrigen",
                        column: x => x.IdEstacionOrigen,
                        principalTable: "Estacion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_IdBicicleta",
                table: "Alquiler",
                column: "IdBicicleta");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_IdCliente",
                table: "Alquiler",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_IdEmpleado",
                table: "Alquiler",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_IdEstacionDestino",
                table: "Alquiler",
                column: "IdEstacionDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_IdEstacionOrigen",
                table: "Alquiler",
                column: "IdEstacionOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_Bicicleta_IdBicicleta",
                table: "Bicicleta",
                column: "IdBicicleta");

            migrationBuilder.CreateIndex(
                name: "IX_Bicicleta_IdEstacion",
                table: "Bicicleta",
                column: "IdEstacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquiler");

            migrationBuilder.DropTable(
                name: "Bicicleta");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Estacion");

            migrationBuilder.DropTable(
                name: "MarcaBicicleta");

            migrationBuilder.DropTable(
                name: "TipoBicicleta");
        }
    }
}

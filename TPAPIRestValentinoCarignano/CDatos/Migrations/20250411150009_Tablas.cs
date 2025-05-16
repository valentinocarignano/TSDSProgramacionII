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
                name: "Duenios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_DUENIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_TIPO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Animales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    IdDuenio = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ANIMAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animales_Duenios_IdDuenio",
                        column: x => x.IdDuenio,
                        principalTable: "Duenios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animales_Tipos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "Tipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atenciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tratamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ATENCION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atenciones_Animales_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdDuenio",
                table: "Animales",
                column: "IdDuenio");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdTipo",
                table: "Animales",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_IdAnimal",
                table: "Atenciones",
                column: "IdAnimal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atenciones");

            migrationBuilder.DropTable(
                name: "Animales");

            migrationBuilder.DropTable(
                name: "Duenios");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROGRAM.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAndControllersCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoría = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodMateriales = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Procedimiento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimiento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ManoDeObra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManoDeObra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ManoDeObra_Categoria_CategoriaRefId",
                        column: x => x.CategoriaRefId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contador",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoRefId = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contador", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContadorRefId = table.Column<int>(type: "int", nullable: true),
                    ProcedimientoRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipo_Contador_ContadorRefId",
                        column: x => x.ContadorRefId,
                        principalTable: "Contador",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Equipo_Procedimiento_ProcedimientoRefId",
                        column: x => x.ProcedimientoRefId,
                        principalTable: "Procedimiento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeTrabajo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoOT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManoDeObraRefId = table.Column<int>(type: "int", nullable: true),
                    EquipoRefId = table.Column<int>(type: "int", nullable: true),
                    ProcedimientoRefId = table.Column<int>(type: "int", nullable: true),
                    MaterialesRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeTrabajo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrdenDeTrabajo_Equipo_EquipoRefId",
                        column: x => x.EquipoRefId,
                        principalTable: "Equipo",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrdenDeTrabajo_ManoDeObra_ManoDeObraRefId",
                        column: x => x.ManoDeObraRefId,
                        principalTable: "ManoDeObra",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrdenDeTrabajo_Materiales_MaterialesRefId",
                        column: x => x.MaterialesRefId,
                        principalTable: "Materiales",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrdenDeTrabajo_Procedimiento_ProcedimientoRefId",
                        column: x => x.ProcedimientoRefId,
                        principalTable: "Procedimiento",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contador_EquipoRefId",
                table: "Contador",
                column: "EquipoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_ContadorRefId",
                table: "Equipo",
                column: "ContadorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_ProcedimientoRefId",
                table: "Equipo",
                column: "ProcedimientoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_ManoDeObra_CategoriaRefId",
                table: "ManoDeObra",
                column: "CategoriaRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeTrabajo_EquipoRefId",
                table: "OrdenDeTrabajo",
                column: "EquipoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeTrabajo_ManoDeObraRefId",
                table: "OrdenDeTrabajo",
                column: "ManoDeObraRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeTrabajo_MaterialesRefId",
                table: "OrdenDeTrabajo",
                column: "MaterialesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeTrabajo_ProcedimientoRefId",
                table: "OrdenDeTrabajo",
                column: "ProcedimientoRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contador_Equipo_EquipoRefId",
                table: "Contador",
                column: "EquipoRefId",
                principalTable: "Equipo",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contador_Equipo_EquipoRefId",
                table: "Contador");

            migrationBuilder.DropTable(
                name: "OrdenDeTrabajo");

            migrationBuilder.DropTable(
                name: "ManoDeObra");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Contador");

            migrationBuilder.DropTable(
                name: "Procedimiento");
        }
    }
}

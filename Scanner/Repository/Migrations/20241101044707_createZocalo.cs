using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class createZocalo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metrics1");

            migrationBuilder.CreateTable(
                name: "zocalos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinTamano = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxTamano = table.Column<int>(type: "INTEGER", nullable: false),
                    PromedioDuracion = table.Column<double>(type: "REAL", nullable: false),
                    PromedioTamañoArchivos = table.Column<double>(type: "REAL", nullable: false),
                    CantidadArchivos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zocalos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "zocalos");

            migrationBuilder.CreateTable(
                name: "Metrics1",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics1", x => x.Id);
                });
        }
    }
}

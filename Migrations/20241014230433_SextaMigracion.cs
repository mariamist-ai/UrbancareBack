using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanCareBack.Migrations
{
    /// <inheritdoc />
    public partial class SextaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoColaborador",
                table: "Colaboradores",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoColaborador",
                table: "Colaboradores");
        }
    }
}

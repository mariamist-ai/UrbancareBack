using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanCareBack.Migrations
{
    /// <inheritdoc />
    public partial class SeptimaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_LogEventos_LogEventoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TiposEvento_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_LogEventoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "LogEventoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoEventoId",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "LogEventoIdLogEvento",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoEvento",
                table: "Eventos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoEventoIdTipoEvento",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LogEventoIdLogEvento",
                table: "Eventos",
                column: "LogEventoIdLogEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoIdTipoEvento",
                table: "Eventos",
                column: "TipoEventoIdTipoEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_LogEventos_LogEventoIdLogEvento",
                table: "Eventos",
                column: "LogEventoIdLogEvento",
                principalTable: "LogEventos",
                principalColumn: "IdLogEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TiposEvento_TipoEventoIdTipoEvento",
                table: "Eventos",
                column: "TipoEventoIdTipoEvento",
                principalTable: "TiposEvento",
                principalColumn: "IdTipoEvento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_LogEventos_LogEventoIdLogEvento",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TiposEvento_TipoEventoIdTipoEvento",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_LogEventoIdLogEvento",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TipoEventoIdTipoEvento",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "LogEventoIdLogEvento",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoEvento",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoEventoIdTipoEvento",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "LogEventoId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoEventoId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LogEventoId",
                table: "Eventos",
                column: "LogEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_LogEventos_LogEventoId",
                table: "Eventos",
                column: "LogEventoId",
                principalTable: "LogEventos",
                principalColumn: "IdLogEvento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TiposEvento_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId",
                principalTable: "TiposEvento",
                principalColumn: "IdTipoEvento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

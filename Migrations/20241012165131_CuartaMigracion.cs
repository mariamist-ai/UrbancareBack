using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanCareBack.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Organizaciones_OrganizacionId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Organizaciones_OrganizacionId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Participaciones_Participantes_ParticipanteId",
                table: "Participaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_TiposDoc_TipoDocId",
                table: "Participantes");

            migrationBuilder.DropTable(
                name: "Organizaciones");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participantes",
                table: "Participantes");

            migrationBuilder.RenameTable(
                name: "Participantes",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "IdParticipante",
                table: "Usuarios",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Participantes_TipoDocId",
                table: "Usuarios",
                newName: "IX_Usuarios_TipoDocId");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDocId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NombreOrg",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Organizacion_Celular",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Ruc",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AdministradorId",
                table: "Usuarios",
                column: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Usuarios_OrganizacionId",
                table: "Colaboradores",
                column: "OrganizacionId",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Usuarios_OrganizacionId",
                table: "Eventos",
                column: "OrganizacionId",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participaciones_Usuarios_ParticipanteId",
                table: "Participaciones",
                column: "ParticipanteId",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TiposDoc_TipoDocId",
                table: "Usuarios",
                column: "TipoDocId",
                principalTable: "TiposDoc",
                principalColumn: "IdTipoDoc");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_AdministradorId",
                table: "Usuarios",
                column: "AdministradorId",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Usuarios_OrganizacionId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Usuarios_OrganizacionId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Participaciones_Usuarios_ParticipanteId",
                table: "Participaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TiposDoc_TipoDocId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_AdministradorId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_AdministradorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NombreOrg",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Organizacion_Celular",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Ruc",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Participantes");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Participantes",
                newName: "IdParticipante");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_TipoDocId",
                table: "Participantes",
                newName: "IX_Participantes_TipoDocId");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDocId",
                table: "Participantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Participantes",
                keyColumn: "Nombre",
                keyValue: null,
                column: "Nombre",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Participantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Participantes",
                keyColumn: "Apellido",
                keyValue: null,
                column: "Apellido",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Participantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participantes",
                table: "Participantes",
                column: "IdParticipante");

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    IdAdministrador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.IdAdministrador);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizaciones",
                columns: table => new
                {
                    IdOrganizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdministradorId = table.Column<int>(type: "int", nullable: false),
                    Celular = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreOrg = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ruc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizaciones", x => x.IdOrganizacion);
                    table.ForeignKey(
                        name: "FK_Organizaciones_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "IdAdministrador",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Organizaciones_AdministradorId",
                table: "Organizaciones",
                column: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Organizaciones_OrganizacionId",
                table: "Colaboradores",
                column: "OrganizacionId",
                principalTable: "Organizaciones",
                principalColumn: "IdOrganizacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Organizaciones_OrganizacionId",
                table: "Eventos",
                column: "OrganizacionId",
                principalTable: "Organizaciones",
                principalColumn: "IdOrganizacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participaciones_Participantes_ParticipanteId",
                table: "Participaciones",
                column: "ParticipanteId",
                principalTable: "Participantes",
                principalColumn: "IdParticipante",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_TiposDoc_TipoDocId",
                table: "Participantes",
                column: "TipoDocId",
                principalTable: "TiposDoc",
                principalColumn: "IdTipoDoc",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

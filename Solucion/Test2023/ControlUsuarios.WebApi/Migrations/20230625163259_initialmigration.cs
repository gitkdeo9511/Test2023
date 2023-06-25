using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlUsuarios.WebApi.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JWT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermisoRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Permiso_PermisoRefId",
                        column: x => x.PermisoRefId,
                        principalTable: "Permiso",
                        principalColumn: "IdPermiso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Rol_RolRefId",
                        column: x => x.RolRefId,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    RolRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolRefId",
                        column: x => x.RolRefId,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "IdPermiso", "Descripcion", "Name" },
                values: new object[] { new Guid("d1b59f44-ed5c-4f3b-8020-670a96190185"), "Permisos de Administrador", "Full" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "IdRol", "Name" },
                values: new object[] { new Guid("3b9d3bd4-77b9-431c-b669-4896868818f5"), "Administrador" });

            migrationBuilder.InsertData(
                table: "RolPermiso",
                columns: new[] { "Id", "PermisoRefId", "RolRefId" },
                values: new object[] { new Guid("d4de80c2-0605-4a58-9258-3a3a21be6103"), new Guid("d1b59f44-ed5c-4f3b-8020-670a96190185"), new Guid("3b9d3bd4-77b9-431c-b669-4896868818f5") });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UserName", "Clave", "EmailAddress", "Enabled", "RolRefId" },
                values: new object[] { "Admin", "w5su1y3SSQu2brHEKX5fp4uZUPfPqqPCOncMoVYHGsE=", "admin@intermail.com", true, new Guid("3b9d3bd4-77b9-431c-b669-4896868818f5") });

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoRefId",
                table: "RolPermiso",
                column: "PermisoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_RolRefId",
                table: "RolPermiso",
                column: "RolRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolRefId",
                table: "Usuario",
                column: "RolRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}

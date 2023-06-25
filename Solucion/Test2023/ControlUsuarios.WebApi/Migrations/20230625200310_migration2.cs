using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlUsuarios.WebApi.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("d4de80c2-0605-4a58-9258-3a3a21be6103"));

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "UserName",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "Permiso",
                keyColumn: "IdPermiso",
                keyValue: new Guid("d1b59f44-ed5c-4f3b-8020-670a96190185"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "IdRol",
                keyValue: new Guid("3b9d3bd4-77b9-431c-b669-4896868818f5"));

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "IdPermiso", "Descripcion", "Name" },
                values: new object[] { new Guid("95bb4cfc-8570-42db-bc45-09cec99060ee"), "Permisos de Cliente", "Cliente" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "IdRol", "Name" },
                values: new object[] { new Guid("9b5f2d1c-13f9-4e9e-ab36-53506b487f37"), "Cliente" });

            migrationBuilder.InsertData(
                table: "RolPermiso",
                columns: new[] { "Id", "PermisoRefId", "RolRefId" },
                values: new object[] { new Guid("0957737f-e38c-4226-89ef-65bd5158487a"), new Guid("95bb4cfc-8570-42db-bc45-09cec99060ee"), new Guid("9b5f2d1c-13f9-4e9e-ab36-53506b487f37") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("0957737f-e38c-4226-89ef-65bd5158487a"));

            migrationBuilder.DeleteData(
                table: "Permiso",
                keyColumn: "IdPermiso",
                keyValue: new Guid("95bb4cfc-8570-42db-bc45-09cec99060ee"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "IdRol",
                keyValue: new Guid("9b5f2d1c-13f9-4e9e-ab36-53506b487f37"));

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
        }
    }
}

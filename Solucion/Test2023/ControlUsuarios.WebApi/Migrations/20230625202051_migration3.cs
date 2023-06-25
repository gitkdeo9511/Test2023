using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlUsuarios.WebApi.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("b4924c0a-609a-4baa-bc84-c2fe241863bf"), "Permisos de Administrador", "Full" },
                    { new Guid("cd864bff-fdd8-4b65-a222-1dec52804be1"), "Permisos de Cliente", "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "IdRol", "Name" },
                values: new object[,]
                {
                    { new Guid("23ecb38c-2b79-4ea7-b818-4d0eac0f1b76"), "Administrador" },
                    { new Guid("bb388e14-1d76-4ca8-b849-69c39dd947be"), "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "RolPermiso",
                columns: new[] { "Id", "PermisoRefId", "RolRefId" },
                values: new object[] { new Guid("ebe22f3a-bf65-4938-8757-4acc2d5952fb"), new Guid("b4924c0a-609a-4baa-bc84-c2fe241863bf"), new Guid("23ecb38c-2b79-4ea7-b818-4d0eac0f1b76") });

            migrationBuilder.InsertData(
                table: "RolPermiso",
                columns: new[] { "Id", "PermisoRefId", "RolRefId" },
                values: new object[] { new Guid("30243cfb-fc14-4957-8009-6e0152933548"), new Guid("cd864bff-fdd8-4b65-a222-1dec52804be1"), new Guid("bb388e14-1d76-4ca8-b849-69c39dd947be") });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UserName", "Clave", "EmailAddress", "Enabled", "RolRefId" },
                values: new object[] { "Admin", "B/SKTsuv5ygdQ+6eT9uhKg47jjn0DKEiuO6cnpGt74Y=", "admin@intermail.com", true, new Guid("23ecb38c-2b79-4ea7-b818-4d0eac0f1b76") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("30243cfb-fc14-4957-8009-6e0152933548"));

            migrationBuilder.DeleteData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("ebe22f3a-bf65-4938-8757-4acc2d5952fb"));

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "UserName",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "Permiso",
                keyColumn: "IdPermiso",
                keyValue: new Guid("b4924c0a-609a-4baa-bc84-c2fe241863bf"));

            migrationBuilder.DeleteData(
                table: "Permiso",
                keyColumn: "IdPermiso",
                keyValue: new Guid("cd864bff-fdd8-4b65-a222-1dec52804be1"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "IdRol",
                keyValue: new Guid("23ecb38c-2b79-4ea7-b818-4d0eac0f1b76"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "IdRol",
                keyValue: new Guid("bb388e14-1d76-4ca8-b849-69c39dd947be"));

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
    }
}

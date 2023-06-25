using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;

namespace ControlUsuarios.WebApi.Models
{
    public class TestSistemaDbContext:DbContext
    {
        public TestSistemaDbContext(DbContextOptions<TestSistemaDbContext> options) : base(options)
        {

        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<RolPermiso> RolesPermisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guidRol = Guid.NewGuid();
            var guidPermiso = Guid.NewGuid();
            var guidRol2 = Guid.NewGuid();
            var guidPermiso2 = Guid.NewGuid();

            modelBuilder.Entity<Rol>().HasData(
                new Rol(guidRol, "Administrador")
            );
            modelBuilder.Entity<Permiso>().HasData(
                new Permiso(guidPermiso, "Full","Permisos de Administrador")
            );
            modelBuilder.Entity<RolPermiso>().HasData(
                new RolPermiso() { Id= Guid.NewGuid(), RolRefId=guidRol,PermisoRefId=guidPermiso}
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario() { RolRefId = guidRol, UserName = "Admin", Clave = Utils.Cryptography.Encrypt("12345678"), EmailAddress = "admin@intermail.com", Enabled = true }
            );

            modelBuilder.Entity<Rol>().HasData(
                new Rol(guidRol2, "Cliente")
            );
            modelBuilder.Entity<Permiso>().HasData(
                new Permiso(guidPermiso2, "Cliente", "Permisos de Cliente")
            );
            modelBuilder.Entity<RolPermiso>().HasData(
                new RolPermiso() { Id = Guid.NewGuid(), RolRefId = guidRol2, PermisoRefId = guidPermiso2 }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

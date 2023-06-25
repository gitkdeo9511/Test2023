using ControlUsuarios.WebApi.Models;
using ControlUsuarios.WebApi.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlUsuarios.WebApi.Service
{
    public class UserService : IUserService
    {
        public UserService(IOptions<AppSettings> appSettings)
        {

        }

        public JWT Authenticate(string username, string password,IConfiguration config)
        {
            JWT tokeninfo = new JWT();
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                var users = context.Usuarios
                    .Include(user => user.Rol)
                    .ToListAsync().Result;

                var userX = users.Count > 0 ? users.Find(x => x.UserName.ToUpper() == username.ToUpper()
                && Utils.Cryptography.Decrypt(x.Clave).ToUpper() == password.ToUpper()) : null;

                if (userX == null)
                    return null;

                var rolpermisos = context.RolesPermisos
                    .Include(per1 => per1.Rol)
                    .Include(per2 => per2.Permiso)
                    .ToListAsync()
                    .Result
                    .Find(x => x.RolRefId == userX.RolRefId);

                var jwt = new JwtService(config);
                tokeninfo.Token = jwt.GenerateSecurityToken(userX.UserName);
                tokeninfo.UserName = userX.UserName;
                tokeninfo.RolPermiso = rolpermisos;

                context.Sessions.Add(new Session(Guid.NewGuid(), tokeninfo.Token, true, DateTime.Now));
                context.SaveChanges();

                return tokeninfo;
            }

        }

        public bool Delete(string idUser)
        {
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {

                var users = context.Usuarios
                    .Include(user => user.Rol)
                    .ToListAsync().Result;

                var userX = users.Count > 0 ? users.Find(x => x.UserName==idUser) : null;

                if (userX == null)
                    return false;

                context.Usuarios.Remove(userX);
                context.SaveChanges();
                return true;
            }
         }

        public List<Usuario> Get()
        {
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                var users = context.Usuarios
                    .Include(user => user.Rol)
                    .ToListAsync().Result;

                return users;
            }
        }

        public Usuario GetById(string idUser)
        {
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                return context.Usuarios
                    .Include(user => user.Rol)
                    .ToListAsync().Result.Find(x=>x.UserName==idUser);
            }
        }

        public bool Registrar(ref Usuario user)
        {
            var id = user.UserName;
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                user.Clave = Utils.Cryptography.Encrypt(user.Clave);
                context.Usuarios.Add(user);
                context.SaveChanges();

                user = context.Usuarios
                    .Include(rol => rol.Rol)
                    .ToListAsync().Result.Find(x=>x.UserName ==id);
            }

            return true;
        }

        public bool Update(ref Usuario user)
        {
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                var userId = user.UserName;
                user.Clave = Utils.Cryptography.Encrypt(user.Clave);
                context.Usuarios.Update(user);
                context.SaveChanges();

                user = context.Usuarios
                    .Include(rol => rol.Rol)
                    .ToListAsync().Result.Find(x => x.UserName == userId);
            }

            return true;
        }
    }
}

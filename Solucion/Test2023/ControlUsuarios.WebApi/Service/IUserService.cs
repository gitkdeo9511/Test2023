using ControlUsuarios.WebApi.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ControlUsuarios.WebApi.Service
{
    public interface IUserService
    {
        JWT Authenticate(string username, string password, IConfiguration config);

        bool Registrar(ref Usuario user);

        List<Usuario> Get();

        Usuario GetById (string idUser);

        bool Update(ref Usuario user);

        bool Delete(string idUser);
    }
}

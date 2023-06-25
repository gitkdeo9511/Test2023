using ControlUsuarios.WebApi.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ControlUsuarios.WebApi.Service
{
    public interface ISessionService
    {
        List<Session> GetSessionsActivas();

        bool ValidarSessionByJWT(string JWT, IConfiguration config);

    }
}

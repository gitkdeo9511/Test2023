using ControlUsuarios.WebApi.Models;
using System.Collections.Generic;

namespace ControlUsuarios.WebApi.Service
{
    public interface IRolService
    {
        List<Rol> Get();
    }
}

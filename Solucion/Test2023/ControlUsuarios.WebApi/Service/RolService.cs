using ControlUsuarios.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ControlUsuarios.WebApi.Service
{
    public class RolService:IRolService
    {
        public List<Rol> Get()
        {
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                var roles = context.Roles
                    .ToListAsync().Result;

                return roles;
            }
        }
    }
}

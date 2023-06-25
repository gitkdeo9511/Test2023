using ControlUsuarios.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ControlUsuarios.WebApi.Service
{
    public class SessionService : ISessionService
    {
        public List<Session> GetSessionsActivas()
        {
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                var sessions = context.Sessions
                    .ToListAsync().Result.FindAll(x=>x.Enabled==true);

                return sessions;
            }
        }

        public bool ValidarSessionByJWT(string JWT, IConfiguration config)
        {
            using (var context = new TestSistemaDbContext(new DbContextOptions<TestSistemaDbContext>()))
            {
                var _expDate = Convert.ToInt32(config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value);

                var today = DateTime.Now;
                var s = context.Sessions
                    .ToListAsync().Result.Find(x => x.JWT == JWT);

                if(s==null || !s.Enabled)
                    return false;

                var diffOfDates = today - s.FechaCreacion;

                if(diffOfDates.Minutes >= _expDate)
                {
                    s.Enabled = false;
                    context.Sessions.Update(s);
                    context.SaveChanges();
                    return false;
                }


                return true;
            }
        }
    }
}

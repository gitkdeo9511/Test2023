using Microsoft.EntityFrameworkCore;

namespace ControlUsuarios.Web.Models.Entities
{
    public class ConexionContext : DbContext
    {
        public ConexionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CookieUser> Users { get; set; }
    }
}
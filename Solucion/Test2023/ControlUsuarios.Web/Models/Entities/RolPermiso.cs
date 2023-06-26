using System;

namespace ControlUsuarios.Web.Models.Entities
{
    public class RolPermiso
    {
        public Guid Id { get; set; }
        public Rol Rol { get; set; }
        public Permiso Permiso { get; set; }
    }
}

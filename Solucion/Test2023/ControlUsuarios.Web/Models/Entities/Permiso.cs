using System;

namespace ControlUsuarios.Web.Models.Entities
{
    public class Permiso
    {
        public Guid IdPermiso { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
    }
}

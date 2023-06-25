using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlUsuarios.WebApi.Models
{
    [Table("RolPermiso")]
    public class RolPermiso
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Rol")]
        public Guid RolRefId { get; set; }
        public Rol Rol { get; set; }

        [ForeignKey("Permiso")]
        public Guid PermisoRefId { get; set; }
        public Permiso Permiso { get; set; }

    }
}

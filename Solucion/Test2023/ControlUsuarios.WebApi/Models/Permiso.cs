using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlUsuarios.WebApi.Models
{
    [Table("Permiso")]
    public class Permiso
    {
        [Key]
        public Guid IdPermiso { get; set; }
        [Required]
        public string Name { get; set; }
		public string Descripcion { get; set; }

        public Permiso(Guid idPermiso, string name, string descripcion)
        {
            IdPermiso = idPermiso;
            Name = name;
            Descripcion = descripcion;
        }
    }
}

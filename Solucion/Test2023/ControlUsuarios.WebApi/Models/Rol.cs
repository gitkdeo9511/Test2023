using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlUsuarios.WebApi.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public Guid IdRol { get; set; }
        [Required]
        public string Name { get; set; }

        public Rol(Guid idRol, string name)
        {
            IdRol = idRol;
            Name = name;
        }
    }
}

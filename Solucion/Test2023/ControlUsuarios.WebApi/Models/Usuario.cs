using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlUsuarios.WebApi.Models
{
    [Table("Usuario")]
    public class Usuario
    {      
        [Key]
        [StringLength(50, ErrorMessage = "UserName no puede ser mayor a 50 caracteres.")]
        public string UserName { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido")]
        public string EmailAddress { get; set; }
        [Required]
        public bool Enabled { get; set; }

        [ForeignKey("Rol")]
        [Required]
        public Guid RolRefId { get; set; }
        public Rol Rol { get; set; }

       
    }
}

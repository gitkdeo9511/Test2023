using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlUsuarios.WebApi.Models
{
    [Table("Session")]
    public class Session
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string JWT { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }

        public Session(Guid id, string jWT, bool enabled, DateTime fechaCreacion)
        {
            Id = id;
            JWT = jWT;
            Enabled = enabled;
            FechaCreacion = fechaCreacion;
        }
    }
}

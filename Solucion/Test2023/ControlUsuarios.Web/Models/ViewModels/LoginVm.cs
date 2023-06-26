using System.ComponentModel.DataAnnotations;

namespace ControlUsuarios.Web.Models
{
    public class LoginVm
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }
    }
}
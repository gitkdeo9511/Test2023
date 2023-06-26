using System.ComponentModel.DataAnnotations;

namespace ControlUsuarios.Web.Models
{
    public class RegisterVm : LoginVm
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string RolRefId { get; set; }
    }
}
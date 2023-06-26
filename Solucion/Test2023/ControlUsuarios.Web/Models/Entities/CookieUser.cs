using System;
using System.ComponentModel.DataAnnotations;

namespace ControlUsuarios.Web.Models.Entities
{
    public class CookieUser
    {
        public string UserName { get; set; }
        public string Clave { get; set; }
        public string EmailAddress { get; set; }
        public bool Enabled { get; set; }
        public string RolRefId { get; set; }
    }
}
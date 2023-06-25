namespace ControlUsuarios.WebApi.Models
{
    public class JWT
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public RolPermiso RolPermiso { get; set; }

    }
}

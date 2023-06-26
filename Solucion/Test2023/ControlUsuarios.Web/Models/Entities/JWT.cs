namespace ControlUsuarios.Web.Models.Entities
{
    public class JWT
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public RolPermiso RolPermiso { get; set; }
    }
}

using ControlUsuarios.Web.Providers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace ControlUsuarios.Web.ActionFilters
{
    public class ActionFilter : IActionFilter
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public ActionFilter(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var cookie = context.HttpContext.Request.Cookies["jwt"];
            if (cookie != null && !string.IsNullOrEmpty(cookie))
            {
                if (!_userRepository.ValidarSession(_config.GetSection("UrlWebApi").Value, cookie))
                {
                    context.Result = new RedirectResult("~/Account/Logout");
                    return;
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}

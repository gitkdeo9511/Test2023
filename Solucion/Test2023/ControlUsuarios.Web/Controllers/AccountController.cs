using System;
using System.Linq;
using System.Threading.Tasks;
using ControlUsuarios.Web.ActionFilters;
using ControlUsuarios.Web.Models;
using ControlUsuarios.Web.Providers;
using ControlUsuarios.Web.Providers.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace ControlUsuarios.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUserRepository _userRepository;
        private IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IUserManager userManager, IUserRepository userRepository, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        [ServiceFilter(typeof(ActionFilter))]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ServiceFilter(typeof(ActionFilter))]
        [Authorize(Roles = "Administrador")]
        public IActionResult Profile()
        {
            string jwt = _httpContextAccessor.HttpContext.Request.Cookies["jwt"];
            return View(_userRepository.GetListaUsuarios(_config.GetSection("UrlWebApi").Value,jwt));
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userRepository.Validate(model, _config.GetSection("UrlWebApi").Value);

            if (user == null) return View(model);

            await _userManager.SignIn(this.HttpContext, user, false);

            UseCookie(user.Token);

            return LocalRedirect("~/Home/Index");
        }

        public IActionResult Register()
        {
            ViewBag.Roles = _userRepository.GetListaRoles(_config.GetSection("UrlWebApi").Value)
                     .Select(i => new SelectListItem
                     {
                         Value = i.IdRol.ToString(),
                         Text = i.Name
                     }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var r = _userRepository.Register(model, _config.GetSection("UrlWebApi").Value);
            if (!r) return View(model);

            var user = _userRepository.Validate(new LoginVm() { UserName=model.UserName,Password=model.Password}, _config.GetSection("UrlWebApi").Value);
            if (user == null) return View(model);

            await _userManager.SignIn(this.HttpContext, user, false);

            UseCookie(user.Token);

            return LocalRedirect("~/Home/Index");
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _userManager.SignOut(this.HttpContext);
            return RedirectPermanent("~/Home/Index");
        }

        internal void UseCookie(string jwt)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("jwt");
            _httpContextAccessor.HttpContext.Response.Cookies.Append("jwt", jwt, cookieOptions);
        }
    }
}
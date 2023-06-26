using ControlUsuarios.WebApi.Models;
using ControlUsuarios.WebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControlUsuarios.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;
        private IConfiguration _config;

        public UserController(IConfiguration config, IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Autenticar(string userName, string clave)
        {
            try
            {
                var user = _userService.Authenticate(userName, clave, _config);
                if (user == null)
                {
                    return BadRequest(new { message = "Username o clave es incorrecta" });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("AuthenticateController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Registrar([FromBody] Usuario user)
        {
            try
            {
                var requestUrl = $"{Request.Scheme}://{Request.Host.Value}/api/User/GetById?userName='";
                if (_userService.Registrar(ref user))
                {
                    requestUrl += user.UserName + "'";
                    return Created(requestUrl, user);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("AuthenticateController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userService.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError("AuthenticateController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult GetById(string userName)
        {
            try
            {
                return Ok(_userService.GetById(userName));
            }
            catch (Exception ex)
            {
                _logger.LogError("AuthenticateController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }

        [Authorize]
        [HttpPut]
        public IActionResult Actualizar([FromBody] Usuario user)
        {
            try
            {
                var requestUrl = $"{Request.Scheme}://{Request.Host.Value}/api/User/GetById?userName='";
                if (_userService.Update(ref user))
                {
                    requestUrl += user.UserName + "'";
                    return Created(requestUrl, user);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("AuthenticateController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }

        [Authorize]
        [HttpDelete]
        public IActionResult Borrar(string userName)
        {
            try
            {
                if (_userService.Delete(userName))
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("AuthenticateController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }
    }
}

using ControlUsuarios.WebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace ControlUsuarios.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private ISessionService _sessionService;
        private IConfiguration _config;

        public SessionController(IConfiguration config, ISessionService sessionService, ILogger<SessionController> logger)
        {
            _sessionService = sessionService;
            _logger = logger;
            _config = config;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_sessionService.GetSessionsActivas());
            }
            catch (Exception ex)
            {
                _logger.LogError("SessionController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ValidarSession(string jwt)
        {
            try
            {
                return Ok(_sessionService.ValidarSessionByJWT(jwt,_config));
            }
            catch (Exception ex)
            {
                _logger.LogError("SessionController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }



    }
}

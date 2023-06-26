using ControlUsuarios.WebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ControlUsuarios.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private IRolService _rolService;

        public RolController(IRolService rolService, ILogger<RolController> logger)
        {
            _rolService = rolService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_rolService.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError("SessionController", ex);
                return BadRequest(new { message = "Error interno" });
            }

        }
    }
}

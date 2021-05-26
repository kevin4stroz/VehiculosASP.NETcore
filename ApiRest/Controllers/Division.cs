using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiRest.Models.CustomModels;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly ILogger<DivisionController> _logger;

        public DivisionController(ILogger<DivisionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(DivisionOperadores operadores)
        {
            // validar que cumpla con los decoradores DataAnnotations
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(new { resultado = operadores.Result });
        }
    }
}
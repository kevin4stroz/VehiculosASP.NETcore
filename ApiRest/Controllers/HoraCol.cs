using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoraColController : ControllerBase
    {
        private readonly ILogger<HoraColController> _logger;

        public HoraColController(ILogger<HoraColController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            string timeZoneId = "";

            // se valida sobre que SO se esta ejecutando la aplicacion y se
            // asigna el Time Zone Id correspondiente al SO
            // README : https://devblogs.microsoft.com/dotnet/cross-platform-time-zones-with-net-core/
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // PATH TimeZoneId /usr/share/zoneinfo/America/Bogota
                timeZoneId = "America/Bogota";
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Cayman Islands 	KY 	SA Pacific Standard Time 	(UTC-05:00) 	Bogota, Lima, Quito, Rio Branco
                // https://docs.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones
                timeZoneId = "SA Pacific Standard Time";
            }
            else
            {
                return Problem("TimeZoneID no encontrado (win/linux)");
            }

            // Obtener TimeZoneInfo a partir de TimeZoneId
            var coTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            // Convertir TimeZoneInfo a DateTime
            DateTime coTime = TimeZoneInfo.ConvertTime(
                                        DateTime.Now, 
                                        TimeZoneInfo.Local, 
                                        coTimeZone
            );

            // Creacion de objeto anonimo para retonar informacion
            var horaActualColombia = new {
                fecha_colombia = coTime.ToString("dd-mm-yyyy"),
                hora_colombia = coTime.ToString("HH:mm:ss")
            };

            // retornar objeto horaActualColombia
            return Ok(horaActualColombia);

        }
        
    }
}
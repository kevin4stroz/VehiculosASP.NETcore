using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRest.Models;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculosController : ControllerBase
    {
        
        private VehiculoDBCTX VehiculoDbCtx;

        public VehiculosController(VehiculoDBCTX ctx)
        {
            VehiculoDbCtx = ctx;
        }

        // listar todos los vehiculos
        [HttpGet("ListaVehiculos")]
        public async Task<IActionResult> GetVehiculos()
        {
            List<Vehiculo> listaVehiculos = await VehiculoDbCtx.Vehiculos
                                                .Include("Marca")
                                                .Include("TipoVehiculo")
                                                .ToListAsync();

            return Ok(listaVehiculos);
        }



        // crear vehiculo nuevo
        [HttpPost("CrearVehiculo")]
        public async Task<IActionResult> PostVehiculo(Vehiculo vehiculo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Marca _marca = await VehiculoDbCtx.Marcas.FindAsync(vehiculo.MarcaId);
            TipoVehiculo _tvehiculo = await VehiculoDbCtx.TipoVehiculos.FindAsync(vehiculo.TipoVehiculoId);

            if( _marca == null || _tvehiculo == null)
            {
                return Ok(new { status = false, msg = "suministre id de marca y tipo vehiculos correctos" });
            }
            else
            {
                VehiculoDbCtx.Vehiculos.Add(vehiculo);
                int registrosAgregados = await VehiculoDbCtx.SaveChangesAsync();

                if(registrosAgregados > 0)
                {
                    return Ok(new {status = true, VehiculoId = vehiculo.VehiculoId});
                }
                else
                {
                    return Ok(new {status = false});
                }
            }
        }
    }
}
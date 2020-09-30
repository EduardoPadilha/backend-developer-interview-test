using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Interfaces;
using FeriasCo.Cortex.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FeriasCo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaServico reservaServico;

        public ReservaController(ReservaServico reservaServico)
        {
            this.reservaServico = reservaServico;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RegistrarReserva(Reserva reserva)
        {
            try
            {
                reservaServico.RegistrarReserva(reserva);
                return Created("/", reserva);
            }
            catch (FeriasCoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

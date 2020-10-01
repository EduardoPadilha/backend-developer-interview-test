using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Interfaces;
using FeriasCo.Cortex.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
                var id = reservaServico.RegistrarReserva(reserva);
                reserva.Id = id;
                var a = Url.Action("Obter", new { id });
                return Created(a, reserva);
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Reserva> Obter(int id)
        {
            var quarto = reservaServico.Obter(id);
            if (quarto != null)
                return quarto;
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Reserva>> ObterTodos()
        {
            var quartos = reservaServico.ObterTodos();
            if (quartos != null)
                return Ok(quartos);
            return NotFound();
        }
    }
}

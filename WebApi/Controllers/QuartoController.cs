using System.Collections.Generic;
using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeriasCo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class QuartoController : ControllerBase
    {
        private readonly QuartoServico quartoServico;

        public QuartoController(QuartoServico quartoServico)
        {
            this.quartoServico = quartoServico;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Quarto> Obter(int id)
        {
            var quarto = quartoServico.Obter(id);
            if (quarto != null)
                return quarto;
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Quarto>> ObterTodos()
        {
            var quartos = quartoServico.ObterTodos();
            if (quartos != null)
                return Ok(quartos);
            return NotFound();
        }
    }
}

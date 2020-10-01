using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Cortex.Servicos
{
    public class QuartoServico
    {
        private readonly IQuartoRepositorio quartoRepositorio;

        public QuartoServico(IQuartoRepositorio quartoRepositorio)
        {
            this.quartoRepositorio = quartoRepositorio;
        }

        public Quarto Obter(int id)
        {
            return quartoRepositorio.Obter(id);
        }

        public List<Quarto> ObterTodos()
        {
            return quartoRepositorio.ObterTodos().ToList();
        }
    }
}

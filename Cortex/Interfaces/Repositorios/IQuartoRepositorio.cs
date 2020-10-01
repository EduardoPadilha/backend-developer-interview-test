using FeriasCo.Cortex.Entidades;
using System.Collections.Generic;

namespace FeriasCo.Cortex.Interfaces.Repositorios
{
    public interface IQuartoRepositorio : IRepositorioConsulta<Quarto>
    {
        IEnumerable<Quarto> ObterTodos();
    }
}

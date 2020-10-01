using FeriasCo.Cortex.Entidades;
using System.Collections.Generic;

namespace FeriasCo.Cortex.Interfaces.Repositorios.Consulta
{
    public interface IQuartoRepositorio : IRepositorioConsulta<Quarto>
    {
        IEnumerable<Quarto> ObterTodos();
    }
}

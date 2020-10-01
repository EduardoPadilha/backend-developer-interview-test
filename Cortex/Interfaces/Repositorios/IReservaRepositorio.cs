using FeriasCo.Cortex.Entidades;
using System.Collections.Generic;

namespace FeriasCo.Cortex.Interfaces.Repositorios
{
    public interface IReservaRepositorio : IRepositorioComando<Reserva>, IRepositorioConsulta<Reserva>
    {
        IEnumerable<Reserva> ObterTodos();
    }
}

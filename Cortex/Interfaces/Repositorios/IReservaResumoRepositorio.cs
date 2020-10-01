using FeriasCo.Cortex.Entidades.Consultas;
using System;

namespace FeriasCo.Cortex.Interfaces.Repositorios
{
    public interface IReservaResumoRepositorio : IRepositorioConsulta<ReservaResumo>, IRepositorioComando<ReservaResumo>
    {
        bool existeReservaNaData(int quartoId, DateTime checkin, DateTime checkout);
    }
}

using FeriasCo.Cortex.Entidades.Consultas;
using System;

namespace FeriasCo.Cortex.Interfaces.Repositorios.Consulta
{
    public interface IReservaResumoRepositorio : IRepositorioConsulta<ReservaResumo>
    {
        bool existeReservaNaData(int quartoId, DateTime checkin, DateTime checkout);
    }
}

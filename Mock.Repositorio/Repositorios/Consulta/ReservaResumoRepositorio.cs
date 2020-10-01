using FeriasCo.Cortex.Entidades.Consultas;
using FeriasCo.Cortex.Interfaces.Repositorios.Consulta;
using System;
using System.Linq;

namespace FeriasCo.Mock.Repositorio.Repositorios.Consulta
{
    public class ReservaResumoRepositorio : IReservaResumoRepositorio
    {

        public bool existeReservaNaData(int quartoId, DateTime checkin, DateTime checkout)
        {
            return Banco.Instancia.Reservas.Any(r => r.Quarto == quartoId && r.Checkin.Date <= checkout.Date && checkin.Date <= r.Checkout.Date);
        }

        public ReservaResumo Obter(int id)
        {
            return Banco.Instancia.Reservas.FirstOrDefault(r => r.Id == id);
        }
    }
}

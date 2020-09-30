using FeriasCo.Cortex.Entidades.Consultas;
using FeriasCo.Cortex.Interfaces.Repositorios.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Mock.Repositorio.Repositorios.Consulta
{
    public class ReservaResumoRepositorio : IReservaResumoRepositorio
    {
        private readonly List<ReservaResumo> reservas = new List<ReservaResumo>
        {
            #region Quarto 1
            new ReservaResumo
            {
                Id = 1,
                Quarto = 1,
                Checkin = new DateTime(2020, 10, 5),
                Checkout = new DateTime(2020, 10, 10)
            },
            new ReservaResumo
            {
                Id = 2,
                Quarto = 1,
                Checkin = new DateTime(2020, 10, 12),
                Checkout = new DateTime(2020, 10, 15)
            },
            #endregion
            #region Quarto 2
            new ReservaResumo
            {
                Id = 3,
                Quarto = 2,
                Checkin = new DateTime(2020, 10, 1),
                Checkout = new DateTime(2020, 10, 5)
            },
            new ReservaResumo
            {
                Id = 4,
                Quarto = 2,
                Checkin = new DateTime(2020, 10, 6),
                Checkout = new DateTime(2020, 10, 10)
            },
            #endregion
            #region Quarto 3
            new ReservaResumo
            {
                Id = 5,
                Quarto = 3,
                Checkin = new DateTime(2020, 10, 1),
                Checkout = new DateTime(2020, 10, 31)
            },
            #endregion
            #region Quarto 5
            new ReservaResumo
            {
                Id = 6,
                Quarto = 5,
                Checkin = new DateTime(2020, 10, 5),
                Checkout = new DateTime(2020, 10, 6)
            },
            new ReservaResumo
            {
                Id = 7,
                Quarto = 5,
                Checkin = new DateTime(2020, 10, 9),
                Checkout = new DateTime(2020, 10, 10)
            },
            #endregion
        };

        public bool existeReservaNaData(int quartoId, DateTime checkin, DateTime checkout)
        {
            return reservas.Any(r => r.Quarto == quartoId && r.Checkin.Date <= checkout.Date && checkin <= r.Checkout);
        }

        public ReservaResumo Obter(int id)
        {
            return reservas.FirstOrDefault(r => r.Id == id);
        }
    }
}

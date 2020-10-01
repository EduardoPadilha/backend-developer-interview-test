using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Entidades.Consultas;
using System;
using System.Collections.Generic;

namespace FeriasCo.Mock.Repositorio
{
    public class Banco
    {
        static Banco _instancia;
        public static Banco Instancia
        {
            get { return _instancia ?? (_instancia = new Banco()); }
        }
        public List<Quarto> Quartos = new List<Quarto>
        {
            new Quarto
            {
                Descricao = "Quarto 1",
                Capacidade = 1,
                Id = 1
            },
            new Quarto
            {
                Descricao = "Quarto 2",
                Capacidade = 2,
                Id = 2
            },
            new Quarto
            {
                Descricao = "Quarto 3",
                Capacidade = 3,
                Id = 3
            },
            new Quarto
            {
                Descricao = "Quarto 5",
                Capacidade = 5,
                Id = 5
            },
        };

        public List<ReservaResumo> Reservas = new List<ReservaResumo>
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
    }
}

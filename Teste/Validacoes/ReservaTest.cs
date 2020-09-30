using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FeriasCo.Teste.Validacoes
{
    public class ReservaTest
    {
        private readonly HospedeValidador hospedeValidacao;
        private readonly QuartoDaReservaValidador quartoValidacao;
        private readonly ReservaValidador reservaValidacao;

        static readonly List<Hospede> hospedes = new List<Hospede>
        {
            //Validando Nascimento
            new Hospede
            {
                Nome = "Eduardo Padilha",
                Cpf = "01234567891",
            },
            //Validando CPF
            new Hospede
            {
                Nome = "Eduardo Padilha",
                Cpf = "012345678",
                Nascimento = new DateTime(1900, 1,1)
            },
            //Validando Nome
            new Hospede
            {
                Cpf = "01234567891",
                Nascimento = new DateTime(1900, 1,1)
            },
            //Validando Full
            new Hospede(),
            //Valido
            new Hospede
            {
                Nome = "Eduardo Padilha",
                Cpf = "01234567891",
                Nascimento = new DateTime(1999, 1, 1)
            },
            //Valido Pagante
            new Hospede
            {
                Nome = "Eduardo Padilha",
                Cpf = "01234567891",
                Nascimento = new DateTime(1999, 1, 1),
                Pagante = true
            }
        };
        static readonly List<QuartoDaReserva> quartos = new List<QuartoDaReserva>
        {
            //validar Hospedes
            new QuartoDaReserva
            {
                Hospedes = hospedes.Take(2).ToList()
            },
            //validar Hospedes vazio
            new QuartoDaReserva
            {
            },
            //Valido
            new QuartoDaReserva
            {
                Hospedes = hospedes.Skip(4).Take(1).ToList()
            },
            //Valido com pagante
            new QuartoDaReserva
            {
                Hospedes = hospedes.Skip(5).ToList()
            }
        };
        static readonly List<Reserva> reservas = new List<Reserva>
        {
            //Validar props
            new Reserva(),
            //Validar Pagante
            new Reserva
            {
                Checkin = new DateTime(2020, 12,12),
                Checkout = new DateTime(2020, 12, 15),
                Quartos = quartos.Skip(2).Take(1).ToList()
            },
            //Valido
            new Reserva
            {
                Checkin = new DateTime(2020, 12,12),
                Checkout = new DateTime(2020, 12, 15),
                Quartos = quartos.Skip(3).ToList()
            }

        };

        public ReservaTest()
        {
            hospedeValidacao = new HospedeValidador();
            quartoValidacao = new QuartoDaReservaValidador();
            reservaValidacao = new ReservaValidador();
        }

        [Fact]
        public void ValidarHospedes()
        {
            var resultadoValidacao = hospedeValidacao.Validar(hospedes[0]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            resultadoValidacao = hospedeValidacao.Validar(hospedes[1]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            resultadoValidacao = hospedeValidacao.Validar(hospedes[2]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            resultadoValidacao = hospedeValidacao.Validar(hospedes[3]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            resultadoValidacao = hospedeValidacao.Validar(hospedes[4]);
            Assert.True(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
        }

        [Fact]
        public void ValidarQuartos()
        {
            var resultadoValidacao = quartoValidacao.Validar(quartos[0]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            resultadoValidacao = quartoValidacao.Validar(quartos[1]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            resultadoValidacao = quartoValidacao.Validar(quartos[2]);
            Assert.True(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
        }

        [Fact]
        public void ValidarReserva()
        {
            var resultadoValidacao = reservaValidacao.Validar(reservas[0]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            Assert.True(resultadoValidacao.Erros.Count == 4);

            resultadoValidacao = reservaValidacao.Validar(reservas[1]);
            Assert.False(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
            Assert.True(resultadoValidacao.Erros.Count == 1);

            resultadoValidacao = reservaValidacao.Validar(reservas[2]);
            Assert.True(resultadoValidacao.Valido, resultadoValidacao.ToString("\n"));
        }
    }
}

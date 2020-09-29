using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Validacoes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Teste.Validacoes
{
    public class ReservaTest
    {
        private readonly HospedeValidacao hospedeValidacao;
        private readonly QuartoDaReservaValidacao quartoValidacao;
        private readonly ReservaValidacao reservaValidacao;

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
            //Valida Capacidade
            new QuartoDaReserva
            {
                Capacidade = 2,
                Hospedes = hospedes
            },
            //validar Hospedes
            new QuartoDaReserva
            {
                Capacidade = 2,
                Hospedes = hospedes.Take(2).ToList()
            },
            //validar Hospedes vazio
            new QuartoDaReserva
            {
                Capacidade = 2,
            },
            //Valido
            new QuartoDaReserva
            {
                Capacidade = 2,
                Hospedes = hospedes.Skip(4).Take(1).ToList()
            },
            //Valido com pagante
            new QuartoDaReserva
            {
                Capacidade = 2,
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
                Quartos = quartos.Skip(3).Take(1).ToList()
            },
            //Valido
            new Reserva
            {
                Checkin = new DateTime(2020, 12,12),
                Checkout = new DateTime(2020, 12, 15),
                Quartos = quartos.Skip(4).ToList()
            }

        };

        public ReservaTest()
        {
            hospedeValidacao = new HospedeValidacao();
            quartoValidacao = new QuartoDaReservaValidacao();
            reservaValidacao = new ReservaValidacao();
        }

        [Fact]
        public void ValidarHospedes()
        {
            var resultadoValidacao = hospedeValidacao.Validate(hospedes[0]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            resultadoValidacao = hospedeValidacao.Validate(hospedes[1]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            resultadoValidacao = hospedeValidacao.Validate(hospedes[2]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            resultadoValidacao = hospedeValidacao.Validate(hospedes[3]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            resultadoValidacao = hospedeValidacao.Validate(hospedes[4]);
            Assert.True(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
        }

        [Fact]
        public void ValidarQuartos()
        {
            var resultadoValidacao = quartoValidacao.Validate(quartos[0]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            resultadoValidacao = quartoValidacao.Validate(quartos[1]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            resultadoValidacao = quartoValidacao.Validate(quartos[2]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            resultadoValidacao = quartoValidacao.Validate(quartos[3]);
            Assert.True(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
        }

        [Fact]
        public void ValidarReserva()
        {
            var resultadoValidacao = reservaValidacao.Validate(reservas[0]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            Assert.True(resultadoValidacao.Errors.Count == 4);

            resultadoValidacao = reservaValidacao.Validate(reservas[1]);
            Assert.False(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
            Assert.True(resultadoValidacao.Errors.Count == 1);

            resultadoValidacao = reservaValidacao.Validate(reservas[2]);
            Assert.True(resultadoValidacao.IsValid, EscreveErros(resultadoValidacao.Errors));
        }

        private static string EscreveErros(IList<ValidationFailure> erros)
        {
            return string.Join("\n", erros.Select(e => e.ErrorMessage));
        }
    }
}

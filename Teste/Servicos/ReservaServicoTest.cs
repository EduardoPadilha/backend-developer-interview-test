using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Excecoes;
using FeriasCo.Cortex.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FeriasCo.Teste.Servicos
{
    public class ReservaServicoTest : TesteBase
    {
        private readonly ReservaServico servico;
        public ReservaServicoTest() : base()
        {
            servico = container.GetInstance<ReservaServico>();
        }

        protected Reserva reserva = new Reserva
        {
            Checkin = new DateTime(2020, 10, 20),
            Checkout = new DateTime(2020, 10, 30),
            Quartos = new List<QuartoDaReserva>
                {
                    new QuartoDaReserva
                    {
                        Id = 1,
                        Hospedes = new List<Hospede>
                        {
                            new Hospede
                            {
                                Cpf = "01234567891",
                                Nascimento = new DateTime(1990,1,1),
                                Nome = "Fulaninho de Tal",
                                Pagante = true
                            }
                        }
                    }
                }
        };

        [Fact]
        public void LogicaValidador()
        {
            var hospede = reserva.Quartos.FirstOrDefault().Hospedes.FirstOrDefault();
            hospede.Nome = null;
            hospede.Pagante = false;
            Assert.Throws<ValidacaoException>(() => servico.RegistrarReserva(reserva));
        }

        [Fact]
        public void ValidarQuartoInexistente()
        {
            var quarto = reserva.Quartos.FirstOrDefault();
            quarto.Id = 4;
            Assert.Throws<QuartoInexistenteException>(() => servico.RegistrarReserva(reserva));
        }

        [Fact]
        public void ValidarQuartoLotado()
        {
            var quarto = reserva.Quartos.FirstOrDefault();
            quarto.Hospedes.Add(new Hospede
            {
                Cpf = "01234567892",
                Nascimento = new DateTime(2010, 1, 1),
                Nome = "Fulaninho de Tal Jr",
            });
            Assert.Throws<QuartoLotadoException>(() => servico.RegistrarReserva(reserva));
        }

        [Fact]
        public void ValidarQuartoIndisponivel()
        {
            reserva.Checkin = new DateTime(2020, 10, 15);
            Assert.Throws<QuartoIndisponivelException>(() => servico.RegistrarReserva(reserva));
        }

        [Fact]
        public void ValidarRegistroReserva()
        {
            servico.RegistrarReserva(reserva);
        }
    }
}

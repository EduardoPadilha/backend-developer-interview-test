using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Entidades.Consultas;
using FeriasCo.Cortex.Excecoes;
using FeriasCo.Cortex.Interfaces;
using FeriasCo.Cortex.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeriasCo.Cortex.Servicos
{
    public class ReservaServico
    {
        private readonly IValidador<Reserva> validador;
        private readonly IReservaRepositorio repositorio;
        private readonly IReservaResumoRepositorio repositorioResumo;
        private readonly IQuartoRepositorio quartoRepositorio;

        public ReservaServico(IValidador<Reserva> validador, IReservaRepositorio repositorio,
            IReservaResumoRepositorio repositorioResumo, IQuartoRepositorio quartoRepositorio)
        {
            this.validador = validador;
            this.repositorio = repositorio;
            this.repositorioResumo = repositorioResumo;
            this.quartoRepositorio = quartoRepositorio;
        }
        public int RegistrarReserva(Reserva reserva)
        {
            var resultado = validador.Validar(reserva);
            if (!resultado.Valido)
                throw new ValidacaoException(resultado);

            ValidarQuartos(reserva);

            var id = repositorio.Adicionar(reserva);

            Task.Run(() => AtualizaReservaResumo(reserva));

            return id;
        }

        private void AtualizaReservaResumo(Reserva reserva)
        {
            foreach (var quarto in reserva.Quartos)
            {
                var resumo = new ReservaResumo
                {
                    Checkin = reserva.Checkin,
                    Checkout = reserva.Checkout,
                    Quarto = quarto.Id,
                };
                repositorioResumo.Adicionar(resumo);
            }
        }

        private void ValidarQuartos(Reserva reserva)
        {
            foreach (var quartoReserva in reserva.Quartos)
            {
                var quarto = quartoRepositorio.Obter(quartoReserva.Id);
                if (quarto == null)
                    throw new QuartoInexistenteException(quartoReserva.Id);

                if (quartoReserva.Hospedes.Count > quarto.Capacidade)
                    throw new QuartoLotadoException(quarto.Id);

                var dataIndisponivel = repositorioResumo.existeReservaNaData(quarto.Id, reserva.Checkin, reserva.Checkout);
                if (dataIndisponivel)
                    throw new QuartoIndisponivelException(quarto.Id);
            }
        }

        public Reserva Obter(int id)
        {
            return repositorio.Obter(id);
        }

        public List<Reserva> ObterTodos()
        {
            return repositorio.ObterTodos().ToList();
        }
    }
}

using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Excecoes;
using FeriasCo.Cortex.Interfaces;
using FeriasCo.Cortex.Interfaces.Repositorios.Comando;
using FeriasCo.Cortex.Interfaces.Repositorios.Consulta;

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
        public void RegistrarReserva(Reserva reserva)
        {
            var resultado = validador.Validar(reserva);
            if (!resultado.Valido)
                throw new ValidacaoException(resultado);

            ValidarQuartos(reserva);

            repositorio.Adicionar(reserva);
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
    }
}

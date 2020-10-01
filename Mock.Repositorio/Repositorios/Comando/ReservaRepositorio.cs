using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Entidades.Consultas;
using FeriasCo.Cortex.Interfaces.Repositorios.Comando;
using System.Linq;

namespace FeriasCo.Mock.Repositorio.Repositorios.Comando
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        public void Adicionar(Reserva entidade)
        {
            var proxId = Banco.Instancia.Reservas.Max(c => c.Id) + 1;
            foreach (var quarto in entidade.Quartos)
            {
                Banco.Instancia.Reservas.Add(new ReservaResumo
                {
                    Checkin = entidade.Checkin,
                    Checkout = entidade.Checkout,
                    Quarto = quarto.Id,
                    Id = proxId
                });
                proxId++;
            }
        }

        public void Editar(Reserva entidade)
        {
        }

        public void Remover(Reserva entidade)
        {
        }
    }
}

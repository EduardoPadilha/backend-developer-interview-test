using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Entidades.Consultas;
using FeriasCo.Cortex.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Mock.Repositorio.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        public Reserva Obter(int id)
        {
            return Banco.Instancia.Reservas.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Reserva> ObterTodos()
        {
            return Banco.Instancia.Reservas;
        }

        public int Adicionar(Reserva entidade)
        {
            var reservas = Banco.Instancia.Reservas;
            var proxId = reservas.Any() ? reservas.Max(c => c.Id) + 1 : 1;
            entidade.Id = proxId;
            reservas.Add(entidade);
            return proxId;
        }

        public void Editar(Reserva entidade)
        {
        }

        public void Remover(Reserva entidade)
        {
        }
    }
}

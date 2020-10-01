using FeriasCo.Cortex.Entidades.Consultas;
using FeriasCo.Cortex.Interfaces.Repositorios;
using System;
using System.Linq;

namespace FeriasCo.Mock.Repositorio.Repositorios
{
    public class ReservaResumoRepositorio : IReservaResumoRepositorio
    {
        public bool existeReservaNaData(int quartoId, DateTime checkin, DateTime checkout)
        {
            return Banco.Instancia.ReservasResumo.Any(r => r.Quarto == quartoId && r.Checkin.Date <= checkout.Date && checkin.Date <= r.Checkout.Date);
        }

        public ReservaResumo Obter(int id)
        {
            return Banco.Instancia.ReservasResumo.FirstOrDefault(r => r.Id == id);
        }

        public int Adicionar(ReservaResumo entidade)
        {
            var proxId = Banco.Instancia.ReservasResumo.Max(c => c.Id) + 1;
            entidade.Id = proxId;
            Banco.Instancia.ReservasResumo.Add(entidade);
            return proxId;
        }

        public void Editar(ReservaResumo entidade)
        {
        }

        public void Remover(ReservaResumo entidade)
        {
        }
    }
}

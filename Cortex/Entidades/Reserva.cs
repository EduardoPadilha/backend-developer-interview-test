using System;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Cortex.Entidades
{
    public class Reserva : EntidadeBase
    {
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public List<QuartoDaReserva> Quartos { get; set; }
        public Hospede Pagante => Quartos?.SelectMany(c => c.Hospedes)?.FirstOrDefault(c => c.Pagante);
        public bool HaPagante => Pagante != null;
    }

    public class QuartoDaReserva : EntidadeBase
    {
        public int Capacidade { get; set; }
        public List<Hospede> Hospedes { get; set; }
        public bool SuperLotado => (Hospedes?.Count ?? 0) > Capacidade;
    }

    public class Hospede : EntidadeBase
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public bool Pagante { get; set; }
    }

}

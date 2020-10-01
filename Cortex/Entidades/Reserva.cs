using System;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Cortex.Entidades
{
    public class Reserva : EntidadeBase
    {
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public List<QuartoDaReserva> Quartos { get; set; } = new List<QuartoDaReserva>();
    }

    public class QuartoDaReserva : EntidadeBase
    {
        public List<Hospede> Hospedes { get; set; } = new List<Hospede>();
    }

    public class Hospede : EntidadeBase
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public bool Pagante { get; set; }
    }

}

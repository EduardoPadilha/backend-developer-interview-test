using System;

namespace FeriasCo.Cortex.Entidades.Consultas
{
    public class ReservaResumo : EntidadeBase
    {
        public int Quarto { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
    }
}

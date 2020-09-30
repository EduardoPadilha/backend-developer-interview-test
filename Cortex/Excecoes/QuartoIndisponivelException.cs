using System;

namespace FeriasCo.Cortex.Excecoes
{
    public class QuartoIndisponivelException : Exception
    {
        public QuartoIndisponivelException(int id) : base($"O quarto {id} está indiponível para as datas da reserva")
        {
        }
    }
}

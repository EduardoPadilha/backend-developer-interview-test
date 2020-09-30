using System;

namespace FeriasCo.Cortex.Excecoes
{
    public class QuartoLotadoException : Exception
    {
        public QuartoLotadoException(int id) : base($"O quarto {id} está acima da capacidade permitida")
        {
        }
    }
}

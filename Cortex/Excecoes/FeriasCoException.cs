using System;

namespace FeriasCo.Cortex.Interfaces
{
    public class FeriasCoException : Exception
    {
        public FeriasCoException(string mensagem) : base(mensagem)
        {
        }
    }
}

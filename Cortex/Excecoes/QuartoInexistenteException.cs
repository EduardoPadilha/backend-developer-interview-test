using System;

namespace FeriasCo.Cortex.Excecoes
{
    public class QuartoInexistenteException : Exception
    {
        public QuartoInexistenteException(int id) : base($"O quarto com id {id} não existe")
        {
        }
    }
}

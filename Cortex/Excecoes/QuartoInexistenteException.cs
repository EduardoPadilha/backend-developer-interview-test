using FeriasCo.Cortex.Interfaces;

namespace FeriasCo.Cortex.Excecoes
{
    public class QuartoInexistenteException : FeriasCoException
    {
        public QuartoInexistenteException(int id) : base($"O quarto com id {id} não existe")
        {
        }
    }
}

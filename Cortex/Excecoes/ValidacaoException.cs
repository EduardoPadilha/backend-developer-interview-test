using FeriasCo.Cortex.Interfaces;

namespace FeriasCo.Cortex.Excecoes
{
    public class ValidacaoException : FeriasCoException
    {
        public ValidacaoException(IResultadoValidacao resultado) : base($"Erro de validação: {resultado.ToString("\n")}")
        {
        }
    }
}

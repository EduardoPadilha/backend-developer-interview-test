using FeriasCo.Cortex.Interfaces;
using System;

namespace FeriasCo.Cortex.Excecoes
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(IResultadoValidacao resultado) : base($"Erro de validação: {resultado.ToString("\n")}")
        {
        }
    }
}

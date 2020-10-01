using System.Collections.Generic;

namespace FeriasCo.Cortex.Interfaces
{
    public interface IValidador<TEntidade>
    {
        IResultadoValidacao Validar(TEntidade entidade);
    }

    public interface IResultadoValidacao
    {
        bool Valido { get; }
        IEnumerable<IFalhaValidacao> Erros { get; }
        string ToString(string separador);
    }

    public interface IFalhaValidacao
    {
        string NomePropriedade { get; }
        string MensagemErro { get; }
    }
}

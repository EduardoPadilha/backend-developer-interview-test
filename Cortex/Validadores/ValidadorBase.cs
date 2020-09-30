using FeriasCo.Cortex.Interfaces;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Cortex.Validadores
{
    public abstract class ValidadorBase<TEntidade> : AbstractValidator<TEntidade>, IValidador<TEntidade>
    {
        public IResultadoValidacao Validar(TEntidade entidade)
        {
            var resultado = Validate(entidade);
            return new ResultadoValidacao(resultado.IsValid,
                            resultado.Errors.Select(e => new FalhaValidacao(e.PropertyName, e.ErrorMessage))
                            .Cast<IFalhaValidacao>()
                            .ToList()
                );
        }
    }

    public class ResultadoValidacao : IResultadoValidacao
    {
        public ResultadoValidacao(bool valido, IEnumerable<IFalhaValidacao> erros)
        {
            this.Valido = valido;
            this.Erros = erros;
        }
        public bool Valido { get; }
        public IEnumerable<IFalhaValidacao> Erros { get; }

        public string ToString(string separador)
        {
            return string.Join(separador, Erros.Select(e => e.MensagemErro));
        }
    }

    public class FalhaValidacao : IFalhaValidacao
    {
        public FalhaValidacao(string nomePropriedade, string mensagemErro)
        {
            this.NomePropriedade = nomePropriedade;
            this.MensagemErro = mensagemErro;
        }
        public string NomePropriedade { get; }
        public string MensagemErro { get; }

        public override string ToString()
        {
            return $"{NomePropriedade}: {MensagemErro}";
        }
    }
}

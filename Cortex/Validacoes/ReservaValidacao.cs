using FeriasCo.Cortex.Entidades;
using FluentValidation;

namespace FeriasCo.Cortex.Validacoes
{
    public class ReservaValidacao : AbstractValidator<Reserva>
    {
        public ReservaValidacao()
        {
            RuleFor(x => x.Checkin)
                .NotEmpty()
                .WithMessage("Uma data de chekin precisa ser informada");

            RuleFor(x => x.Checkout)
                .NotEmpty()
                .WithMessage("Uma data de chekout precisa ser informada");

            RuleFor(x => x.Quartos)
                .NotEmpty()
                .WithMessage("Pelo menos um quarto precisa ser informado");

            RuleForEach(x => x.Quartos)
                .SetValidator(new QuartoDaReservaValidacao());

            RuleFor(x => x.HaPagante)
               .Equal(true)
               .WithMessage("O responsável pelo pagamento da reserva deve ser informado");
        }
    }

    public class QuartoDaReservaValidacao : AbstractValidator<QuartoDaReserva>
    {
        public QuartoDaReservaValidacao()
        {
            RuleFor(x => x.SuperLotado)
                .Equal(false)
                .WithMessage("Há hóspedes acima da capacidade permitida do quarto");

            RuleFor(x => x.Hospedes)
                .NotEmpty()
                .WithMessage("Pelo menos um hóspede precisa ser informado");

            RuleForEach(x => x.Hospedes)
                .SetValidator(new HospedeValidacao());
        }
    }

    public class HospedeValidacao : AbstractValidator<Hospede>
    {
        public HospedeValidacao()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O CPF deve ser informado")
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage("O CPF informado é inválido");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O Nome deve ser informado");

            RuleFor(x => x.Nascimento)
                .NotEmpty()
                .WithMessage("A data de nascimento deve ser informada");

        }
    }
}

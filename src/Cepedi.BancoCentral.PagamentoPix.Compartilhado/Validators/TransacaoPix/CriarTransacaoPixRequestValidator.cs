using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;
public class CriarTransacaoPixRequestValidator : AbstractValidator<CriarTransacaoPixRequest>
{
    public CriarTransacaoPixRequestValidator()
    {
        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

        RuleFor(x => x.Data)
            .NotEmpty().WithMessage("A data é obrigatória.");

        RuleFor(x => x.ChavePixOrigem)
           .NotEmpty().WithMessage("A chave do pix de origem é obrigatório.");

        RuleFor(x => x.ChavePixDestino)
            .NotEmpty().WithMessage("A chave do pix de destino é obrigatório.");
    }
}


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

        RuleFor(x => x.ChaveDeSeguranca)
            .NotEmpty().WithMessage("A chave de segurança é obrigatória.");

        RuleFor(x => x.IdPixOrigem)
           .NotEmpty().WithMessage("O ID do Pix de origem é obrigatório.")
           .GreaterThan(0).WithMessage("O ID do Pix de origem deve ser maior que zero.");

        RuleFor(x => x.IdPixDestino)
            .NotEmpty().WithMessage("O ID do Pix de destino é obrigatório.")
            .GreaterThan(0).WithMessage("O ID do Pix de destino deve ser maior que zero.");
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;
using FluentValidation.Validators;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;

public class CriarPixRequestValidator : AbstractValidator<CriarPixRequest>
{
    public CriarPixRequestValidator()
    {
        RuleFor(x => x.ChavePix).NotEmpty().WithMessage("Chave Pix deve ser informada").Length(11, 36).WithMessage("Chave Pix deve ");
        RuleFor(x => x.IdConta).NotEmpty().WithMessage("Id da conta deve ser informado");
        RuleFor(x => x.IdTipoPix).NotEmpty().WithMessage("Id do tipo de pix deve ser informado");
        RuleFor(x => x.IdTipoPix).GreaterThan(0).WithMessage("O tipo do pix deve ser informado");
    }
}
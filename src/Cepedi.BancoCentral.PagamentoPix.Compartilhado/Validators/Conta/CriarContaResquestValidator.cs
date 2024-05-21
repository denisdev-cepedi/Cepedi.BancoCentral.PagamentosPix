using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class CriarContaRequestValidator : AbstractValidator<CriarContaRequest>
    {
        public CriarContaRequestValidator()
        {
            
             RuleFor(request => request.Numero)
            .NotEmpty().WithMessage("Número da instituição é obrigatório.");

        RuleFor(request => request.Agencia)
            .NotEmpty().WithMessage("Agência é obrigatória.")
            .Matches(@"^\d+$").WithMessage("A agência deve ser em formato numérico.");

        RuleFor(request => request.Conta)
            .NotEmpty().WithMessage("Conta é obrigatória.")
            .Matches(@"^\d+$").WithMessage("A conta deve ser em formato numérico.");
        }
    }
}
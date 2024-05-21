using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;

public class ObterPixsByContaBankRequestValidator: AbstractValidator<ObterPixsByContaBankRequest>
{
    public ObterPixsByContaBankRequestValidator(){
        
        //Validação do Código da instituição
        RuleFor(pix => pix.CodigoInstituicao)
            .NotEmpty().WithMessage("O Código da instituição é obrigatório.")
            .Length(1, 3).WithMessage("O Código da instituição deve ter no minimo 1 e no maximo 3 digitos.")
            .Matches(@"^\d+$").WithMessage("O Código da instituição deve conter apenas números.");
        ;

        //Validação da agência
        RuleFor(pix => pix.Agencia)
            .NotEmpty().WithMessage("A agência é obrigatória.")
            .Length(4, 5).WithMessage("A agência deve ter no minimo 4 e no maximo 5 digitos.")
            .Matches(@"^\d+$").WithMessage("A agência deve conter apenas números: Art.2 do Inciso IVº ISO 13.616 ");

        //Validação da conta 
        RuleFor(pix => pix.Conta)
            .NotEmpty().WithMessage("A conta é obrigatória.")
            .Length(5, 9).WithMessage("A conta deve ter no minimo 9 digitos sem o diito verificador");

    }
}
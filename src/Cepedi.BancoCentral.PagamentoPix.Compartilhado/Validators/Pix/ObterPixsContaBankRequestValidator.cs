using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;

public class ObterPixsByContaBankRequestValidator: AbstractValidator<ObterPixsByContaBankRequest>
{
    public ObterPixsByContaBankRequestValidator(){
        
        //Validação do Código da instituição
        RuleFor(pix => pix.CodigoInstituicao).CodigoInstituicaoRules();

        //Validação da agência
        RuleFor(pix => pix.Agencia).AgenciaRules();

        //Validação da conta 
        RuleFor(pix => pix.Conta).ContaRules();

    }
}
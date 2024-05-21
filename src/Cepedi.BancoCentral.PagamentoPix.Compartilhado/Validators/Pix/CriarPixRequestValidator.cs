
using System.Data;
using System.Security.Principal;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;
using FluentValidation.Validators;
using static Cepedi.BancoCentral.PagamentoPix.Compartilhado.Utils.Utils;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;

public class CriarPixRequestValidator : AbstractValidator<CriarPixRequest>
{
    public CriarPixRequestValidator()
    {
       
        RuleFor(pix => pix.CodigoInstituicao).CodigoInstituicaoRules();
    
        RuleFor(pix => pix.Agencia).AgenciaRules();

        RuleFor(pix => pix.Conta).ContaRules();
        //calidação do campo do tipo pix
        RuleFor(request => request.TipoPix).TipoPixRules();
        //Validação do chave pix
        RuleFor(request => request.ChavePix)
                .ChavePixNotEmpty()
                .DependentRules(() =>
                {
                    //aleatória
                    When(request => request.TipoPix == "4", () =>
                    {
                        RuleFor(request => request.ChavePix).ChavePixAleatoria();
                            
                    });
                    //email
                    When(request => request.TipoPix == "2", () =>
                    {
                        RuleFor(request => request.ChavePix).ChavePixEmail();
                    });
                    //tcelular
                    When(request => request.TipoPix == "3", () =>
                    {
                        RuleFor(request => request.ChavePix).ChavePixTelefone();
                    });
                    //cpf
                    When(request => request.TipoPix == "1", () =>
                    {
                    RuleFor(request => request.ChavePix).ChavePixCpf();
                    });

                });
    }  
}


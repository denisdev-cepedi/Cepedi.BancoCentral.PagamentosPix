
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;
using FluentValidation;
using FluentValidation.Validators;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;


public class ObterPixByChavePixRequestValidator : AbstractValidator<ObterPixByChavePixRequest>{


    public ObterPixByChavePixRequestValidator(){

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
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
public class PagamentosPix
{
    public static readonly ResultadoErro Generico = new()
    {
        Titulo = "Ops ocorreu um erro no nosso sistema",
        Descricao = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static readonly ResultadoErro ContaJaExistente= new(){

        Titulo = "Conta ja existente no sistema",
        Descricao = "Esta conta ja existe. Por favor, escolha outro",
        Tipo = ETipoErro.Alerta
    };

    public static readonly ResultadoErro SemResultados = new()
    {
        Titulo = "Sua busca não obteve resultados",
        Descricao = "Tente buscar novamente",
        Tipo = ETipoErro.Alerta
    };

    public static ResultadoErro ErroGravacaoUsuario = new()
    {
        Titulo = "Ocorreu um erro na gravação",
        Descricao = "Ocorreu um erro na gravação do usuário. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro PixInexistente = new()
    {
        Titulo = "Chave PIX inexistente",
        Descricao = "A chave PIX informada não foi localizada",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro ChavePixInvalida = new()
    {
        Titulo = "Chave PIX inválida",
        Descricao = "A chave PIX enviada é inválida",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro ChavePixJaCadastrada = new()
    {
        Titulo = "Chave PIX inválida",
        Descricao = "A chave PIX enviada está em uso",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro ContaInexistente = new()
    {
        Titulo = "Conta inexistente",
        Descricao = "A conta informada não existe",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro DadosInvalidos = new()
    {
        Titulo = "Dados inválidos",
        Descricao = "Os dados enviados na requisição são inválidos",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro CpfNaoVinculado = new()
    {
        Titulo = "CPF não vinculado",
        Descricao = "O CPF fornecido não está vinculado à pessoa proprietária da conta.",
        Tipo = ETipoErro.Alerta
    };



    public static ResultadoErro ChavesPixIguais = new()
    {
        Titulo = "Chaves pix iguais",
        Descricao = "A chave de origem e a chave de destino são iguais",
        Tipo = ETipoErro.Erro
    };
    public static ResultadoErro PessoaJaCadastrada = new()
    {
        Titulo = "Pessoa ja cadastrada",
        Descricao = "A pessoa informada está em uso",
        Tipo = ETipoErro.Alerta
    };

    public static ResultadoErro PessoaInexistente = new()
    {
        Titulo = "Pessoa não encontrada",
        Descricao = "Não foi encontrada a pessoa",
        Tipo = ETipoErro.Alerta
    };
}

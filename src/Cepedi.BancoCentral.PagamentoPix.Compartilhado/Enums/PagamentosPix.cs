﻿using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
public class PagamentosPix
{
    public static readonly ResultadoErro Generico = new()
    {
        Titulo = "Ops ocorreu um erro no nosso sistema",
        Descricao = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
        Tipo = ETipoErro.Erro
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

    public static ResultadoErro PixInexistente = new(){
        Titulo = "Chave PIX inexistente",
        Descricao = "A chave PIX informada não foi localizada",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro ChavePixInvalida = new(){
        Titulo = "Chave PIX inválida",
        Descricao = "A chave PIX enviada é inválida",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro ChavePixJaCadastrada = new(){
        Titulo = "Chave PIX inválida",
        Descricao = "A chave PIX enviada está em uso",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro ContaInexistente = new(){
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

     public static ResultadoErro ChavesPixIguais = new(){
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
    
    public static ResultadoErro PessoaInexistente = new(){
        Titulo = "Pessoa não encontrada",
        Descricao = "Não foi encontrada a pessoa",
        Tipo = ETipoErro.Alerta
    };
    public static ResultadoErro CpfComPixJaCadastrado = new(){
        Titulo = "Cpf atual tem um PIX cadastrado. Não é possivel atualizar o Cpf",
        Descricao = "O Cpf informado está em uso",
        Tipo = ETipoErro.Alerta
    };
}

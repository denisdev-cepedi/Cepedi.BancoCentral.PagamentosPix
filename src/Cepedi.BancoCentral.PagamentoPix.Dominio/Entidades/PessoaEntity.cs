namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

public class PessoaEntity
{
    public int IdPessoa { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public string IdConta { get; set; } = default!;
    
    internal void Atualizar(string nome, string cpf, string idConta)
    {
        Nome = nome;
        Nome = cpf;
        IdConta = idConta;
    }

}

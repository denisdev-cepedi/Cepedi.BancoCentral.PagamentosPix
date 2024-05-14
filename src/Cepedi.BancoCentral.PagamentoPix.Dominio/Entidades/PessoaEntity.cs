namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

public class PessoaEntity
{
    public int IdPessoa { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    
    public DateTime DataCriacao { get; set; }
    
    public DateTime DataAlteracao { get; set; }
    
    public DateTime DataExclusao { get; set; }
    public ICollection<ContaEntity> Contas { get; set; } = default!;

     internal void Atualizar(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }
}

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

public class PessoaEntity
{
    public int IdPessoa { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string IdConta { get; set; }
}

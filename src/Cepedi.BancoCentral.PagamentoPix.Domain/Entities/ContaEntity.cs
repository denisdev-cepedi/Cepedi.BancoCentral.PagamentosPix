namespace Cepedi.BancoCentral.PagamentoPix.Domain.Entities;

public class ContaEntity
{
    public int IdConta { get; set; }
    public int IdPessoa { get; set; }
    public string Numero { get; set; } = default!; //numero da instituição pertencedora
    public required string Agencia { get; set; }
    public required string Conta { get; set; } = default!;
    public ICollection<PixEntity> Pixs { get; set; }
}
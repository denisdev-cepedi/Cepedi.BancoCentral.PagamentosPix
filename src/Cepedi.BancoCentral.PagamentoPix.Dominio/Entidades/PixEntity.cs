namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
public class PixEntity
{
    public int IdPix { get; set; }

    public int IdConta { get; set; }
    public ContaEntity Conta { get; set; }

    public int IdPessoa { get; set; }

    public string ChavePix { get; set; } = default!;

    public int IdTipoPix { get; set; }

    public DateTime DataCriacao { get; set; }

    public string Status { get; set; } = default!;

    public class TipoPixClass{
        public int IdTipoPix { get; set; }

        public string Nome { get; set; } = default!;
    }
    
    public enum TipoPix{
        Cpf = 1,
        email = 2,
        telefone = 3,
        chaveAleatoria = 4
    }

}

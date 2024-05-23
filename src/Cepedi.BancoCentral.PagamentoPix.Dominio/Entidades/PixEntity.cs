namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

/// <summary>
/// IdPix, IdConta, ChavePix, IdTipoPix, DataCriacao, Status
/// </summary>
public class PixEntity
{
    public int IdPix { get; set; }

    public int IdConta { get; set; }

    public required ContaEntity Conta { get; set; }

    public string ChavePix { get; set; } = default!;

    public int IdTipoPix { get; set; }

    public DateTime DataCriacao { get; set; }

    public bool Status { get; set; } = default!;

    public ICollection<TransacaoPixEntity> TransacoesPixsEnviadas { get; set; } = default!;
    public ICollection<TransacaoPixEntity> TransacoesPixsRecebidas { get; set; } = default!;

    public class TipoPixClass{
        public int IdTipoPix { get; set; }

        public string Nome { get; set; } = default!;
    }
    
    public enum TipoPix{
        CPF = 1,
        Email = 2,
        Telefone = 3,
        ChaveAleatoria = 4 
    }

    internal void Desabilitar()
    {
        Status = false;
    }
    internal void Ativar()
    {
        Status = true;
    }

}



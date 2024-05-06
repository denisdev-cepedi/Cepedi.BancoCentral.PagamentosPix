namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

public class  TransacaoPixEntity
{
    public int IdTransacaoPix { get; set; }

    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public string ChaveDeSeguranca { get; set; }

    public int IdPixOrigem { get; set; }

    public int IdPixDestino  { get; set; }
   
    public PixEntity PixOrigem { get; set; }
    
    public PixEntity PixDestino { get; set; }

}

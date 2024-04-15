namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

public class TransacaoPixEntity
{
    public int Id { get; set; }

    public double Valor { get; set; }

    public DateTime Data { get; set; }

    public string ChavePix { get; set; }
    public string ChaveDeSeguranca { get; set; }

    public int IdPixOrigem { get; set; }

   public int IdPixDestino  { get; set; }

}

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

public class TransacaoPixEntity
{
    public int Id { get; set; }

    public double Valor { get; set; }

    public DateTime Data { get; set; }

    public string ChavePix { get; set; }

    public string ChaveDeSeguranca { get; set; }

    public int IdContaOrigem { get; set; }

    public int IdContaDestino  { get; set; }
   
    public ContaEntity ContaOrigem { get; set; }
    
    public ContaEntity ContaDestino { get; set; }

}

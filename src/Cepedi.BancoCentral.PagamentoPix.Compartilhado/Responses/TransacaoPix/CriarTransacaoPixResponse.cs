namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
public record CriarTransacaoPixResponse(int IdTransacaoPix, decimal Valor, string ChaveDeSeguranca);

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;

public record ObterPixsResponse(int idPix, int idConta, string chavePix, bool status, DateTime dataCriacao);
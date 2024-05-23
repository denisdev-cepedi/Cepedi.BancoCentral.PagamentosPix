namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;

public record ObterPixsByContaBankResponse(int IdPix, string tipoDeChave, string chave, string status);
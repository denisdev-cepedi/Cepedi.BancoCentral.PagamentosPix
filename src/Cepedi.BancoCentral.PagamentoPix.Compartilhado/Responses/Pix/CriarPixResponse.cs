namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;

public record CriarPixResponse(int IdPix, string TipoDeChave, string chave, string status);
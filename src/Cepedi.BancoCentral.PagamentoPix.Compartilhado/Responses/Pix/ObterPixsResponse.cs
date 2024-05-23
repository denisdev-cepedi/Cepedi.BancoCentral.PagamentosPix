namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;

public record ObterPixsResponse (int idPix,string codigoInstituicao, string chavePix, string tipoPix, string status);
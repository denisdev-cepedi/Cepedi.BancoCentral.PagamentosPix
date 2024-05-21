namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;

public record ObterPixByChavePixResponse(int IdPix, string codigoInstituicao, string ChavePix, string TipoPix,string Status);
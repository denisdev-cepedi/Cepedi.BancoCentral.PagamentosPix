using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
public class ResultadoErro
{
    public string Titulo { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public ETipoErro Tipo { get; set; }
}

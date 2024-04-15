using Refit;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Services;
public interface IServiceExterno
{
    [Post("api/v1/Enviar")]
    Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] object notificacao);
}

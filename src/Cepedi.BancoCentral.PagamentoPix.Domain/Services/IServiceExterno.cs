using Refit;

namespace Cepedi.BancoCentral.PagamentoPix.Domain.Services;
public interface IServiceExterno
{
    [Post("api/v1/Enviar")]
    Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] object notificacao);
}

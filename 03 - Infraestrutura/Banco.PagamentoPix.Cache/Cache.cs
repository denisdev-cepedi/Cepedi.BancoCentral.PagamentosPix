using System.Text.Json;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Servicos;
using Microsoft.Extensions.Caching.Distributed;

namespace Cepedi.BancoCentral.PagamentosPix.Cache
{
    // A classe Cache<T> implementa a interface ICache<T>, permitindo operações de cache para objetos do tipo T.
    public class Cache<T> : ICache<T>
    {
        // Campo privado para armazenar a instância do cache distribuído.
        private readonly IDistributedCache _cache;

        // Construtor que recebe uma instância de IDistributedCache via injeção de dependência.
        public Cache(IDistributedCache cache)
        {
            _cache = cache;
        }

        // Método assíncrono para obter um objeto do cache usando uma chave fornecida.
        public async Task<T> ObterAsync(string chave)
        {
            // Tenta obter a string JSON do cache usando a chave.
            var json = await _cache.GetStringAsync(chave);
            // Se a string JSON for nula (não encontrada no cache), retorna o valor padrão de T.
            if(json == null) return default!;

            // Deserializa a string JSON de volta para um objeto do tipo T e o retorna.
            return JsonSerializer.Deserialize<T>(json);
        }

        // Método assíncrono para salvar um objeto no cache com uma chave e um tempo de expiração opcional.
        public async Task SalvarAsync(string chave, T objeto, int tempoExpiracao = 10)
        {
            // Serializa o objeto para uma string JSON e armazena no cache com opções de expiração.
            await _cache.SetStringAsync(chave, JsonSerializer.Serialize(objeto), new DistributedCacheEntryOptions()
            {
                // Define a expiração absoluta para o tempo atual mais o tempo de expiração em segundos.
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(tempoExpiracao)       
            });
        }
    }
}

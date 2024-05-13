using Microsoft.Extensions.Options;
using RotaViagem.Domain.Config;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Service.Base;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Interfaces.Services;

namespace RotaViagem.Domain.Services.Base
{
    public class CacheServiceLocal<TContext> : ICacheServiceLocal<TContext>
        where TContext : IUnitOfWork<TContext>
    {
        private readonly TemplateConfig _config;
        private readonly string _prefix = "cache_";
        private readonly ICacheService<TContext> _service;

        public CacheServiceLocal(IOptions<TemplateConfig> config,
            ICacheService<TContext> service)
        {
            _config = config.Value;
            _service = service;
        }

        public void InicializaCache()
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - Iniciando Carregamento do Cache");
            _service.CarregaTabela<Rota>(_config.MinutosExpiracaoCache, _prefix);
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - Fim Carregamento do Cache");
        }
    }
}






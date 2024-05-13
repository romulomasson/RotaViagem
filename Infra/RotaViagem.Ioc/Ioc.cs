
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RotaViagem.Application;
using RotaViagem.Domain.Bases;
using RotaViagem.Domain.Config;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Interfaces.Application;
using RotaViagem.Domain.Interfaces.Bases;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces.Service;
using RotaViagem.Domain.Interfaces.Services;
using RotaViagem.Domain.Services;
using RotaViagem.Repository.Contexts;
using RotaViagem.Repository.Repositories;

namespace RotaViagem.IoC
{
    public static class Ioc
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SendGridConfig>(configuration.GetSection(nameof(SendGridConfig)));
            services.Configure<DocuSignConfig>(configuration.GetSection(nameof(DocuSignConfig)));

            services.AddDbContextPool<RotaViagemContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork<RotaViagemContext>, RotaViagemContext>();

            // Base
            services.AddScoped(typeof(IApplicationBase<,>), typeof(ApplicationBase<,>));
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            services.AddScoped(typeof(IUsuarioApplication<>), typeof(UsuarioApplication<>));
            services.AddScoped(typeof(IUsuarioService<>), typeof(UsuarioService<>));
            services.AddScoped(typeof(IUsuarioRepository<>), typeof(UsuarioRepository<>));

            services.AddScoped(typeof(IRotaApplication<>), typeof(RotaApplication<>));
            services.AddScoped(typeof(IRotaService<>), typeof(RotaService<>));
            services.AddScoped(typeof(IRotaRepository<>), typeof(RotaRepository<>));
        }
    }
}


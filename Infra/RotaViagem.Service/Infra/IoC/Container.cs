using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using RotaViagem.IoC;
using RotaViagem.Service.Tasks;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Service.Helper;
using RotaViagem.Domain.Config;
using Microsoft.Identity.Client;

namespace RotaViagem.Service.Infra.IoC
{
    public static class Container
    {
        public static IServiceProvider Register(IConfiguration configuration)
        {
            var services = new ServiceCollection();

            Ioc.Initialize(services, configuration);
           
            services.RegisterScheduler();
            services.AddScoped<IUserHelper, UsuarioHelper>();

            return services.BuildServiceProvider();
        }

        public static IServiceCollection RegisterScheduler(this IServiceCollection services)
        {
            services.AddScoped(x =>
            {
                var sched = new StdSchedulerFactory().GetScheduler()
                    .GetAwaiter()
                    .GetResult();

                sched.JobFactory = new JobTaskFactory(x);
                return sched;
            });

            return services;
        }
    }
}










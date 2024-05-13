using RotaViagem.Domain.Bases;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Application;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces.Service;

namespace RotaViagem.Application;

public class RotaApplication<TContext> : ApplicationBase<TContext, Rota>, IRotaApplication<TContext>
    where TContext : IUnitOfWork<TContext>
{
    private readonly IRotaService<TContext> _service;
    public RotaApplication(IUnitOfWork<TContext> context, IRotaService<TContext> service) 
        : base(context, service)
    {
        _service = service;
    }

    public Rota ObterMelhorRota(string origem, string destino)
    {
        return _service.ObterMelhorRota(origem,destino);
    }
}
	







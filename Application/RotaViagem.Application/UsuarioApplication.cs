using RotaViagem.Domain.Bases;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Application;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces.Service;

namespace RotaViagem.Application;

public class UsuarioApplication<TContext> : ApplicationBase<TContext, Usuario>, IUsuarioApplication<TContext>
    where TContext : IUnitOfWork<TContext>
{
    private readonly IUsuarioService<TContext> _service;
    public UsuarioApplication(IUnitOfWork<TContext> context, IUsuarioService<TContext> service) 
        : base(context, service)
    {
        _service = service;
    }
   
}
	







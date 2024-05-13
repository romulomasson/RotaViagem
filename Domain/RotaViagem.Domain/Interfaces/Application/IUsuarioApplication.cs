

using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Interfaces.Bases;

namespace RotaViagem.Domain.Interfaces.Application
{
    public interface IUsuarioApplication<TContext> : IApplicationBase<TContext, Usuario>
        where TContext : IUnitOfWork<TContext>
    {
        
    }
}

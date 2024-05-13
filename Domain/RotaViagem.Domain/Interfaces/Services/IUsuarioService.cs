using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace RotaViagem.Domain.Interfaces.Service
{
    public interface IUsuarioService<TContext> : IBaseService<TContext, Usuario>
        where TContext : IUnitOfWork<TContext>
    {
    }
}	

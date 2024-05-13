using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace RotaViagem.Domain.Interfaces.Service
{
    public interface IRotaService<TContext> : IBaseService<TContext, Rota>
        where TContext : IUnitOfWork<TContext>
    {

        public Rota ObterMelhorRota(string origem, string destino);
    }
}	

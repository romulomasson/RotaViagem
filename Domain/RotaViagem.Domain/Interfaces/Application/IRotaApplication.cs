using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Bases;

namespace RotaViagem.Domain.Interfaces.Application;

public interface IRotaApplication<TContext> : IApplicationBase<TContext, Rota>
    where TContext : IUnitOfWork<TContext>
{
    public Rota ObterMelhorRota(string origem, string destino);
}
	






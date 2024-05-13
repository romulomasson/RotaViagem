using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Bases;

namespace RotaViagem.Domain.Interfaces.Repository;

public interface IRotaRepository<TContext> : IRepositoryBase<TContext, Rota>
    where TContext : IUnitOfWork<TContext>
{
    public Rota ObterMelhorRota(string origem, string destino);
}
	
	

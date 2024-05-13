using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Bases;

namespace RotaViagem.Domain.Interfaces.Repository;

public interface IUsuarioRepository<TContext> : IRepositoryBase<TContext, Usuario>
    where TContext : IUnitOfWork<TContext>
{   
}
	
	

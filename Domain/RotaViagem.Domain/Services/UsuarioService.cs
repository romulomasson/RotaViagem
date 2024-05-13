using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces.Service;

namespace RotaViagem.Domain.Services
{
    public class UsuarioService<TContext> : BaseService<TContext, Usuario>, IUsuarioService<TContext>
     where TContext : IUnitOfWork<TContext>
    {
        private readonly IUsuarioRepository<TContext> _repository;

        public UsuarioService(IUsuarioRepository<TContext> repository, IUnitOfWork<TContext> unitOfWork,IUserHelper user) : base(repository, unitOfWork, user)
        {
            _repository = repository;
        }
       
    }
}	

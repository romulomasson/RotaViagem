using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Interfaces.Repository;
using RotaViagem.Domain.Interfaces.Service;

namespace RotaViagem.Domain.Services
{
    public class RotaService<TContext> : BaseService<TContext, Rota>, IRotaService<TContext>
     where TContext : IUnitOfWork<TContext>
    {
        private readonly IRotaRepository<TContext> _repository;

        public RotaService(IRotaRepository<TContext> repository, IUnitOfWork<TContext> unitOfWork,IUserHelper user) : base(repository, unitOfWork, user)
        {
            _repository = repository;
        }

        public Rota ObterMelhorRota(string origem, string destino)
        {
            return _repository.ObterMelhorRota(origem, destino);
        }
    }
}	

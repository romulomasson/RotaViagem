using RotaViagem.Domain.Bases;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using RotaViagem.Exceptions;

namespace RotaViagem.Repository.Repositories
{
    public class RotaRepository<TContext> : RepositoryBase<TContext, Rota>, IRotaRepository<TContext>
       where TContext : IUnitOfWork<TContext>
    {
        private DbSet<Rota> _dbSet => ((Contexts.RotaViagemContext)UnitOfWork).Set<Rota>();

        public RotaRepository(IUnitOfWork<TContext> context) : base(context) { }

        public Rota ObterMelhorRota(string origem, string destino)
        {
            var melhorRota = _dbSet
                .Where(f => f.Origem == origem 
                && f.Destino == destino
                && f.Ativo).OrderBy(x => x.Custo)
                .FirstOrDefault();

            if (melhorRota == null)
                throw new DomainException("RotaRepository", "ObterMelhorRota", "Registro não encontrado");

            return melhorRota;
        }
    }
}	

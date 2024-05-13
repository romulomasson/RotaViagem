using RotaViagem.Domain.Bases;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace RotaViagem.Repository.Repositories
{
    public class UsuarioRepository<TContext> : RepositoryBase<TContext, Usuario>, IUsuarioRepository<TContext>
       where TContext : IUnitOfWork<TContext>
    {
        private DbSet<Usuario> _dbSet => ((Contexts.RotaViagemContext)UnitOfWork).Set<Usuario>();

        public UsuarioRepository(IUnitOfWork<TContext> context) : base(context) { }
               

        public override Usuario Get(int id)
        {
            return _dbSet
                .FirstOrDefault(p => p.Id == id);
        }
    }
}	

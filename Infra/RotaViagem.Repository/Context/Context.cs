
using Microsoft.EntityFrameworkCore;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Repository.Maps;

namespace RotaViagem.Repository.Contexts
{
    public class RotaViagemContext : DbContext, IUnitOfWork<RotaViagemContext>
    {
        public RotaViagemContext(DbContextOptions<RotaViagemContext> options) : base(options) { }
        public int Commit() => this.SaveChanges();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RotaMap());
        }
    }
}


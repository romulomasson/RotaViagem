namespace RotaViagem.Domain.Interfaces
{
    public interface IUnitOfWork<TContext>
    {
        int Commit();
    }
}



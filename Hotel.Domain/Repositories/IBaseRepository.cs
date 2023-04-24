namespace Hotel.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity? GetById( int id );
        IReadOnlyList<TEntity> GetAll();
        void Add( TEntity item );
        void Update( TEntity item );
        void Delete( TEntity item );
    }
}
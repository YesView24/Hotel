using Hotel.Domain.Repositories;
using Hotel.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;

        public BaseRepository( HotelDbContext dbContext )
        {
            _entities = dbContext.Set<TEntity>();
        }

        public TEntity? GetById( int id ) => _entities.Find( id );

        public IReadOnlyList<TEntity> GetAll() => _entities.ToList();

        public void Add( TEntity entity ) => _entities.Add( entity );

        public void Update( TEntity entity ) => _entities.Update( entity );

        public void Delete( TEntity entity ) => _entities.Remove( entity );
    }
}
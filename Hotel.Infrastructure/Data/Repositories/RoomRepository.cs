using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;
using Hotel.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Data.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly HotelDbContext _dbContext;
        private DbSet<Room> _dbSet;

        public RoomRepository( HotelDbContext dbContext ) : base( dbContext )
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Room>();
        }

        public IReadOnlyList<Room> GetAllEmptyRooms() => 
            _dbSet.AsNoTracking()
                  .Include( x => x.Reservations )
                  .Where( x => x.Reservations.Count == 0 )
                  .ToList();
    }
}
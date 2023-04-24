using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;
using Hotel.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Data.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly HotelDbContext _dbContext;
        private DbSet<Reservation> _dbSet;

        public ReservationRepository( HotelDbContext dbContext ) : base( dbContext )
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Reservation>();
        }

        public IReadOnlyList<Guest> GetAllGuestsInRoom( int roomId ) =>
            _dbSet.AsNoTracking()
                  .Where( x => x.RoomId == roomId )
                  .Select( x => x.Guest )
                  .ToList();
    }
}
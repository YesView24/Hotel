using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;
using Hotel.Infrastructure.Foundation;

namespace Hotel.Infrastructure.Data.Repositories
{
    public class GuestRepository : BaseRepository<Guest>, IGuestRepository
    {
        public GuestRepository( HotelDbContext dbContext ) : base( dbContext )
        { }
    }
}
using Hotel.Domain.Entities;

namespace Hotel.Domain.Repositories
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        IReadOnlyList<Guest> GetAllGuestsInRoom( int roomId );
    }
}

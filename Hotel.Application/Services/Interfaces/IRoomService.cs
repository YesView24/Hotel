using Hotel.Application.Features.Reservations.Commands.Creating;

namespace Hotel.Application.Services.Interfaces
{
    public interface IRoomService
    {
        void AddGuest( AddReservationCommand addReservationCommand );
        void RemoveGuest( int roomId, int guestId );
    }
}
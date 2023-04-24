using Hotel.Domain.Entities;

namespace Hotel.Application.Exceptions.Conflict
{
    public class GuestHasReservationInRoomConflictException : ConflictException
    {
        public GuestHasReservationInRoomConflictException( int guestId, int roomId ) : base(
             $"For a guest with id: {guestId} a room with id: {roomId} is already reserved." )
        { }
    }
}

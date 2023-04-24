using Hotel.Domain.Entities;

namespace Hotel.Application.Exceptions.NotFound
{
    public class GuestInRoomNotFoundException : NotFoundException
    {
        public GuestInRoomNotFoundException( int guestId, int roomId ) : base(
            $"Guest with id: {guestId} is not reserved in the room with id: {roomId}." )
        { }
    }
}
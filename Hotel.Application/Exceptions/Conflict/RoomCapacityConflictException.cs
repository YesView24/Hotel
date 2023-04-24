using Hotel.Domain.Entities;

namespace Hotel.Application.Exceptions.Conflict
{
    public class RoomCapacityConflictException : ConflictException
    {
        public RoomCapacityConflictException( int roomId ) : base(
            $"Room with id: {roomId} has reached its maximum capacity. There are no more seats available." )
        { }
    }
}

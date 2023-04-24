namespace Hotel.Application.Exceptions.NotFound
{
    public class RoomNotFoundException : NotFoundException
    {
        public RoomNotFoundException( int roomId ) : base(
            $"Room with id: {roomId} does not exist in the database." )
        { }
    }
}
namespace Hotel.Application.Exceptions.NotFound
{
    public class GuestNotFoundException : NotFoundException
    {
        public GuestNotFoundException( int guestId ) : base(
            $"Guest with id: {guestId} does not exist in the database." )
        { }
    }
}
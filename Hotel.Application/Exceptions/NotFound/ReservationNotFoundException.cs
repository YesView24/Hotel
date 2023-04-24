namespace Hotel.Application.Exceptions.NotFound
{
    public class ReservationNotFoundException : NotFoundException
    {
        public ReservationNotFoundException( int reservationId ) : base(
            $"Reservation with id: {reservationId} does not exist in the database." )
        { }
    }
}
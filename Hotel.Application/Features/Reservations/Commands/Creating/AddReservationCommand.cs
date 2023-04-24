namespace Hotel.Application.Features.Reservations.Commands.Creating
{
    public record AddReservationCommand( DateTime StartDate, DateTime EndDate, int GuestId, int RoomId );
}
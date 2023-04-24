using Hotel.Domain.Entities;

namespace Hotel.API.Dtos
{
    public record ReservationDto( int Id, DateTime StartDate, DateTime EndDate, int GuestId, int RoomId );
}
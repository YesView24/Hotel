using Hotel.Domain.Entities;

namespace Hotel.API.Dtos
{
    public record AddReservationCommandDto( DateTime StartDate, DateTime EndDate, int GuestId, int RoomId );
}


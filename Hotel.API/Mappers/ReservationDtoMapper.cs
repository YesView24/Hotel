using Hotel.API.Dtos;
using Hotel.Domain.Entities;

namespace Hotel.API.Mappers
{
    public static class ReservationDtoMapper
    {
        public static ReservationDto Map( this Reservation command )
        {
            return new ReservationDto( command.Id, command.StartDate, command.EndDate, command.GuestId, command.RoomId );
        }
    }
}

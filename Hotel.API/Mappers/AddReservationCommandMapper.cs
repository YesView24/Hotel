using Hotel.API.Dtos;
using Hotel.Application.Features.Reservations.Commands.Creating;

namespace Hotel.API.Mappers
{
    public static class AddReservationCommandMapper
    {
        public static AddReservationCommand Map( this AddReservationCommandDto command )
        {
            return new AddReservationCommand( command.StartDate, command.EndDate, command.GuestId, command.RoomId );
        }
    }
}


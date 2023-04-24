using Hotel.API.Dtos;
using Hotel.Application.Features.Guests.Commands.Creating;

namespace Hotel.API.Mappers
{
    public static class AddGuestCommandMapper
    {
        public static AddGuestCommand Map( this AddGuestCommandDto command )
        {
            return new AddGuestCommand( command.Name, command.PhoneNumber );
        }
    }
}
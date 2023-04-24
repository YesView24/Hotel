using Hotel.API.Dtos;
using Hotel.Application.Features.Guests.Commands.Updating;

namespace Hotel.API.Mappers
{
    public static class UpdateGuestCommandMapper
    {
        public static UpdateGuestCommand Map( this UpdateGuestCommandDto command )
        {
            return new UpdateGuestCommand( command.Name, command.PhoneNumber );
        }
    }
}
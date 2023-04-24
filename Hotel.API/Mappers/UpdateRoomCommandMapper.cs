using Hotel.API.Dtos;
using Hotel.Application.Features.Rooms.Commands.Updating;

namespace Hotel.API.Mappers
{
    public static class UpdateRoomCommandMapper
    {
        public static UpdateRoomCommand Map( this UpdateRoomCommandDto command )
        {
            return new UpdateRoomCommand( command.Number, command.Description, command.Capacity );
        }
    }
}
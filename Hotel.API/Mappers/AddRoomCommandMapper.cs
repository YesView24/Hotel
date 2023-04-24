using Hotel.API.Dtos;
using Hotel.Application.Features.Rooms.Commands.Creating;

namespace Hotel.API.Mappers
{
    public static class AddRoomCommandMapper
    {
        public static AddRoomCommand Map( this AddRoomCommandDto command )
        {
            return new AddRoomCommand( command.Number, command.Description, command.Capacity );
        }
    }
}
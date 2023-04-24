using Hotel.API.Dtos;
using Hotel.Domain.Entities;

namespace Hotel.API.Mappers
{
    public static class RoomDtoMapper
    {
        public static RoomDto Map( this Room room )
        {
            return new RoomDto( room.Id, room.Number, room.Description, room.Capacity );
        }
    }
}
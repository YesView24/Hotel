using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Rooms.Queries.GetRoomById
{
    public interface IGetRoomByIdQueryHandler
    {
        Room Handle( int id );
    }

    public class GetRoomByIdQueryHandler : IGetRoomByIdQueryHandler
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomByIdQueryHandler( IRoomRepository roomRepository )
        {
            _roomRepository = roomRepository;
        }

        public Room Handle( int id )
        {
            var room = _roomRepository.GetById( id );
            if ( room is null )
                throw new RoomNotFoundException( id );

            return room;
        }
    }
}
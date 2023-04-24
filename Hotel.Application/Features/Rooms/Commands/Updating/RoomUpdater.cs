using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Rooms.Commands.Updating
{
    public interface IRoomUpdater
    {
        void Update( int id, UpdateRoomCommand command );
    }

    public class RoomUpdater : IRoomUpdater
    {
        private readonly IRoomRepository _roomRepository;

        public RoomUpdater( IRoomRepository roomRepository )
        {
            _roomRepository = roomRepository;
        }

        public void Update( int id, UpdateRoomCommand command )
        {
            var room = _roomRepository.GetById( id );
            if ( room is null )
                throw new RoomNotFoundException( id );

            room.Number = command.Number;
            room.Description = command.Description;
            room.Capacity = command.Capacity;

            _roomRepository.Update( room );
        }
    }
}
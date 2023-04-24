using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Rooms.Commands.Creating
{
    public interface IRoomCreator
    {
        void Create( AddRoomCommand command );
    }

    public class RoomCreator : IRoomCreator
    {
        private readonly IRoomRepository _roomRepository;

        public RoomCreator( IRoomRepository roomRepository )
        {
            _roomRepository = roomRepository;
        }

        public void Create( AddRoomCommand command )
        {
            var room = new Room
            {
                Number = command.Number,
                Description = command.Description,
                Capacity = command.Capacity,
            };

            _roomRepository.Add( room );
        }
    }
}
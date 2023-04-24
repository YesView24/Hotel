using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Rooms.Queries.GetAllEmptyRooms
{
    public interface IGetAllEmptyRoomsQueryHandler
    {
        IReadOnlyList<Room> Handle();
    }

    public class GetAllEmptyRoomsQueryHandler : IGetAllEmptyRoomsQueryHandler
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllEmptyRoomsQueryHandler( IRoomRepository roomRepository )
        {
            _roomRepository = roomRepository;
        }

        public IReadOnlyList<Room> Handle() => _roomRepository.GetAllEmptyRooms();
    }
}
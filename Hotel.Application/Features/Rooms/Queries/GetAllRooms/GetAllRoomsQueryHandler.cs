using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Rooms.Queries.GetAllRooms
{
    public interface IGetAllRoomsQueryHandler
    {
        IReadOnlyList<Room> Handle();
    }

    public class GetAllRoomsQueryHandler : IGetAllRoomsQueryHandler
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsQueryHandler( IRoomRepository roomRepository )
        {
            _roomRepository = roomRepository;
        }

        public IReadOnlyList<Room> Handle() => _roomRepository.GetAll();
    }
}
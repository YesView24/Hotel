using Hotel.Domain.Entities;

namespace Hotel.Domain.Repositories
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        IReadOnlyList<Room> GetAllEmptyRooms();
    }
}
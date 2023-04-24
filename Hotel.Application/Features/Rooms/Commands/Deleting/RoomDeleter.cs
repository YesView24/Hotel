using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Rooms.Commands.Deleting
{
    public interface IRoomDeleter
    {
        void Delete( int id );
    }

    public class RoomDeleter : IRoomDeleter
    {
        private readonly IRoomRepository _roomRepository;

        public RoomDeleter( IRoomRepository roomRepository )
        {
            _roomRepository = roomRepository;
        }

        public void Delete( int id )
        {
            var room = _roomRepository.GetById( id );
            if ( room is null )
                throw new RoomNotFoundException( id );

            _roomRepository.Delete( room );
        }
    }
}
using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Rooms.Queries.GetAllGuestsInRoom
{
    public interface IGetAllGuestsInRoomQueryHandler
    {
        IReadOnlyList<Guest> Handle( int roomId );
    }

    public class GetAllGuestsInRoomQueryHandler : IGetAllGuestsInRoomQueryHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllGuestsInRoomQueryHandler( IReservationRepository reservationRepository )
        {
            _reservationRepository = reservationRepository;
        }

        public IReadOnlyList<Guest> Handle( int roomId ) => 
            _reservationRepository.GetAllGuestsInRoom( roomId ).ToList();
    }
}

using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Reservations.Queries.GetAllRoomReservationsQueryHandler
{
    public interface IGetAllRoomReservationsQueryHandler
    {
        IReadOnlyList<Reservation> Handle( int roomId );
    }

    public class GetAllRoomReservationsQueryHandler : IGetAllRoomReservationsQueryHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllRoomReservationsQueryHandler( IReservationRepository reservationRepository )
        {
            _reservationRepository = reservationRepository;
        }

        public IReadOnlyList<Reservation> Handle( int roomId ) => 
            _reservationRepository.GetAll().Where( x => x.RoomId == roomId ).ToList();
    }
}
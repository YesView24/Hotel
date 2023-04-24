using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Reservations.Queries.GetAllReservations
{
    public interface IGetAllReservationsQueryHandler
    {
        IReadOnlyList<Reservation> Handle();
    }

    public class GetAllReservationsQueryHandler : IGetAllReservationsQueryHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllReservationsQueryHandler( IReservationRepository reservationRepository )
        {
            _reservationRepository = reservationRepository;
        }

        public IReadOnlyList<Reservation> Handle() => 
            _reservationRepository.GetAll();
    }
}
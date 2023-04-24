using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Reservations.Queries.GetReservationById
{
    public interface IGetReservationByIdQueryHandler
    {
        Reservation Handle( int id );
    }

    public class GetReservationByIdQueryHandler : IGetReservationByIdQueryHandler
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByIdQueryHandler( IReservationRepository reservationRepository )
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation Handle( int id )
        {
            var reservation = _reservationRepository.GetById( id );
            if ( reservation is null )
                throw new ReservationNotFoundException( id );

            return reservation;
        }
    }
}
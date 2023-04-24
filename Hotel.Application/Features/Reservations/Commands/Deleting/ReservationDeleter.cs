using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Reservations.Commands.Deleting
{
    public interface IReservationDeleter
    {
        void Delete( int id );
    }

    public class ReservationDeleter : IReservationDeleter
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationDeleter( IReservationRepository reservationRepository )
        {
            _reservationRepository = reservationRepository;
        }

        public void Delete( int id )
        {
            var reservation = _reservationRepository.GetById( id );
            if ( reservation is null )
                throw new ReservationNotFoundException( id );

            _reservationRepository.Delete( reservation );
        }
    }
}
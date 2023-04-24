using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Guests.Commands.Deleting
{
    public interface IGuestDeleter
    {
        void Delete( int id );
    }

    public class GuestDeleter : IGuestDeleter
    {
        private readonly IGuestRepository _guestRepository;

        public GuestDeleter( IGuestRepository guestRepository )
        {
            _guestRepository = guestRepository;
        }

        public void Delete( int id )
        {
            var guest = _guestRepository.GetById( id );
            if ( guest is null )
                throw new GuestNotFoundException( id );

            _guestRepository.Delete( guest );
        }
    }
}
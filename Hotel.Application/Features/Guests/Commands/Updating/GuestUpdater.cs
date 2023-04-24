using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Guests.Commands.Updating
{
    public interface IGuestUpdater
    {
        void Update( int id, UpdateGuestCommand command );
    }

    public class GuestUpdater : IGuestUpdater
    {
        private readonly IGuestRepository _guestRepository;

        public GuestUpdater( IGuestRepository GuestRepository )
        {
            _guestRepository = GuestRepository;
        }

        public void Update( int id, UpdateGuestCommand command )
        {
            var guest = _guestRepository.GetById( id );
            if ( guest is null )
                throw new GuestNotFoundException( id );

            guest.Name = command.Name;
            guest.PhoneNumber = command.PhoneNumber;

            _guestRepository.Update( guest );
        }
    }
}
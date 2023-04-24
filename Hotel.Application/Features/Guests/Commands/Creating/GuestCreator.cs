using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Guests.Commands.Creating
{
    public interface IGuestCreator
    {
        void Create( AddGuestCommand command );
    }

    public class GuestCreator : IGuestCreator
    {
        private readonly IGuestRepository _guestRepository;

        public GuestCreator( IGuestRepository guestRepository )
        {
            _guestRepository = guestRepository;
        }

        public void Create( AddGuestCommand command )
        {
            var guest = new Guest
            {
                Name = command.Name,
                PhoneNumber = command.PhoneNumber,
            };

            _guestRepository.Add( guest );
        }
    }
}
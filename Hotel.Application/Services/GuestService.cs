using Hotel.Application.Services.Interfaces;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService( IGuestRepository guestRepository )
        {
            _guestRepository = guestRepository;
        }
    }
}
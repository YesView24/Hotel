using Hotel.Application.Exceptions.NotFound;
using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Guests.Queries.GetGuestById
{
    public interface IGetGuestByIdQueryHandler
    {
        Guest Handle( int id );
    }

    public class GetGuestByIdQueryHandler : IGetGuestByIdQueryHandler
    {
        private readonly IGuestRepository _guestRepository;

        public GetGuestByIdQueryHandler( IGuestRepository guestRepository )
        {
            _guestRepository = guestRepository;
        }

        public Guest Handle( int id )
        {
            var guest = _guestRepository.GetById( id );
            if ( guest is null )
                throw new GuestNotFoundException( id );

            return guest;
        }
    }
}
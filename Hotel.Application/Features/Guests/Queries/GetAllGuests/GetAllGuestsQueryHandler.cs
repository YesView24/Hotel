using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Guests.Queries.GetAllGuests
{
    public interface IGetAllGuestsQueryHandler
    {
        IReadOnlyList<Guest> Handle();
    }

    public class GetAllGuestsQueryHandler : IGetAllGuestsQueryHandler
    {
        private readonly IGuestRepository _guestRepository;

        public GetAllGuestsQueryHandler( IGuestRepository guestRepository )
        {
            _guestRepository = guestRepository;
        }

        public IReadOnlyList<Guest> Handle()
        {
            return _guestRepository.GetAll();
        }

    }
}
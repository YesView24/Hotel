using Hotel.API.Dtos;
using Hotel.Domain.Entities;

namespace Hotel.API.Mappers
{
    public static class GuestDtoMapper
    {
        public static GuestDto Map( this Guest guest )
        {
            return new GuestDto( guest.Id, guest.Name, guest.PhoneNumber );
        }
    }
}
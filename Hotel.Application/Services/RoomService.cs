using Hotel.Application.Exceptions.NotFound;
using Hotel.Application.Features.Guests.Queries.GetGuestById;
using Hotel.Application.Features.Reservations.Commands.Creating;
using Hotel.Application.Features.Reservations.Commands.Deleting;
using Hotel.Application.Features.Reservations.Queries.GetAllRoomReservationsQueryHandler;
using Hotel.Application.Features.Rooms.Queries.GetAllGuestsInRoom;
using Hotel.Application.Features.Rooms.Queries.GetRoomById;
using Hotel.Application.Services.Interfaces;

namespace Hotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IGetGuestByIdQueryHandler _getGuestByIdQueryHandler;
        private readonly IGetRoomByIdQueryHandler _getRoomByIdQueryHandler;
        private readonly IGetAllGuestsInRoomQueryHandler _getAllGuestsInRoomQueryHandler;
        private readonly IGetAllRoomReservationsQueryHandler _getAllRoomReservationsQueryHandler;
        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationDeleter _reservationDeleter;

        public RoomService(
            IGetGuestByIdQueryHandler getGuestByIdQueryHandler,
            IGetRoomByIdQueryHandler getRoomByIdQueryHandler,
            IGetAllGuestsInRoomQueryHandler getAllGuestsInRoomQueryHandler,
            IGetAllRoomReservationsQueryHandler getAllRoomReservationsQueryHandler,
            IReservationCreator reservationCreator,
            IReservationDeleter reservationDeleter )
        {
            _getGuestByIdQueryHandler = getGuestByIdQueryHandler;
            _getRoomByIdQueryHandler = getRoomByIdQueryHandler;
            _getAllGuestsInRoomQueryHandler = getAllGuestsInRoomQueryHandler;
            _getAllRoomReservationsQueryHandler = getAllRoomReservationsQueryHandler;
            _reservationCreator = reservationCreator;
            _reservationDeleter = reservationDeleter;
        }

        public void AddGuest( AddReservationCommand addReservationCommand )
        {
            _reservationCreator.Create( addReservationCommand );
        }

        public void RemoveGuest( int roomId, int guestId )
        {
            _getGuestByIdQueryHandler.Handle( guestId );
            _getRoomByIdQueryHandler.Handle( roomId );

            var guest = _getAllGuestsInRoomQueryHandler.Handle( roomId ).SingleOrDefault( x => x.Id == guestId );
            if ( guest is null )
                throw new GuestInRoomNotFoundException( guestId, roomId );

            var reservation = _getAllRoomReservationsQueryHandler.Handle( roomId )
                                                                 .Single( x => x.GuestId == guestId );

            _reservationDeleter.Delete( reservation.Id );
        }
    }
}
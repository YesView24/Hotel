using Hotel.Application.Exceptions.Conflict;
using Hotel.Application.Features.Guests.Queries.GetGuestById;
using Hotel.Application.Features.Rooms.Queries.GetAllGuestsInRoom;
using Hotel.Application.Features.Rooms.Queries.GetRoomById;
using Hotel.Domain.Entities;
using Hotel.Domain.Repositories;

namespace Hotel.Application.Features.Reservations.Commands.Creating
{
    public interface IReservationCreator
    {
        void Create( AddReservationCommand command );
    }

    public class ReservationCreator : IReservationCreator
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IGetGuestByIdQueryHandler _getGuestByIdQueryHandler;
        private readonly IGetRoomByIdQueryHandler _getRoomByIdQueryHandler;
        private readonly IGetAllGuestsInRoomQueryHandler _getAllGuestsInRoomQueryHandler;


        public ReservationCreator(
            IReservationRepository reservationRepository,
            IGetGuestByIdQueryHandler getGuestByIdQueryHandler,
            IGetRoomByIdQueryHandler getRoomByIdQueryHandler,
            IGetAllGuestsInRoomQueryHandler getAllGuestsInRoomQueryHandler )
        {
            _reservationRepository = reservationRepository;
            _getGuestByIdQueryHandler = getGuestByIdQueryHandler;
            _getRoomByIdQueryHandler = getRoomByIdQueryHandler;
            _getAllGuestsInRoomQueryHandler = getAllGuestsInRoomQueryHandler;
        }

        public void Create( AddReservationCommand command )
        {
            var guestId = command.GuestId;
            var roomId = command.RoomId;

            _getGuestByIdQueryHandler.Handle( guestId );
            var room = _getRoomByIdQueryHandler.Handle( roomId );

            var guests = _getAllGuestsInRoomQueryHandler.Handle( roomId );
            if ( guests.Any( x => x.Id == guestId ) )
                throw new GuestHasReservationInRoomConflictException( guestId, roomId );

            if ( room.Capacity <= guests.Count )
                throw new RoomCapacityConflictException( roomId );

            var reservation = new Reservation
            {
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                GuestId = command.GuestId,
                RoomId = command.RoomId
            };

            _reservationRepository.Add( reservation );
        }
    }
}
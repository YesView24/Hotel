using Hotel.API.Dtos;
using Hotel.API.Mappers;
using Hotel.Application;
using Hotel.Application.Features.Reservations.Commands.Creating;
using Hotel.Application.Features.Rooms.Commands.Creating;
using Hotel.Application.Features.Rooms.Commands.Deleting;
using Hotel.Application.Features.Rooms.Commands.Updating;
using Hotel.Application.Features.Rooms.Queries.GetAllEmptyRooms;
using Hotel.Application.Features.Rooms.Queries.GetAllRooms;
using Hotel.Application.Features.Rooms.Queries.GetRoomById;
using Hotel.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route( "rooms" )]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IGetRoomByIdQueryHandler _getRoomByIdQueryHandler;
        private readonly IGetAllRoomsQueryHandler _getAllRoomsQueryHandler;
        private readonly IGetAllEmptyRoomsQueryHandler _getAllEmptyRoomsQueryHandler;

        private readonly IRoomCreator _roomCreator;
        private readonly IRoomUpdater _roomUpdater;
        private readonly IRoomDeleter _roomDeleter;

        private readonly IRoomService _roomService;

        private readonly IUnitOfWork _unitOfWork;

        public RoomsController(
            IGetRoomByIdQueryHandler getRoomByIdQueryHandler,
            IGetAllRoomsQueryHandler getAllRoomsQueryHandler,
            IGetAllEmptyRoomsQueryHandler getAllEmptyRoomsQueryHandler,
            IRoomCreator roomCreator,
            IRoomUpdater roomUpdater,
            IRoomDeleter roomDeleter,
            IRoomService roomService,
            IUnitOfWork unitOfWork )
        {
            _getRoomByIdQueryHandler = getRoomByIdQueryHandler;
            _getAllRoomsQueryHandler = getAllRoomsQueryHandler;
            _getAllEmptyRoomsQueryHandler = getAllEmptyRoomsQueryHandler;
            _roomCreator = roomCreator;
            _roomUpdater = roomUpdater;
            _roomDeleter = roomDeleter;
            _roomService = roomService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet( "{id}" )]
        public IActionResult GetById( int id )
        {
            var room = _getRoomByIdQueryHandler.Handle( id ).Map();

            return Ok( room );
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _getAllRoomsQueryHandler.Handle().Select( r => r.Map() );

            return Ok( rooms );
        }

        [HttpGet( "empty" )]
        public IActionResult GetAllEmpty()
        {
            var rooms = _getAllEmptyRoomsQueryHandler.Handle().Select( r => r.Map() );

            return Ok( rooms );
        }

        [HttpPost]
        public IActionResult Add( [FromBody] AddRoomCommandDto addRoomCommandDto )
        {
            _roomCreator.Create( addRoomCommandDto.Map() );
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpPost( "{roomId}/guests/{guestId}" )]
        public IActionResult AddGuest( int roomId, int guestId, [FromBody] ReservationDatesDto reservationDatesDto )
        {
            var addReservationCommand = new AddReservationCommand(
                reservationDatesDto.StartDate,
                reservationDatesDto.EndDate,
                guestId,
                roomId );
            _roomService.AddGuest( addReservationCommand );

            _unitOfWork.Commit();

            return Ok();
        }

        [HttpPatch( "{id}" )]
        public IActionResult Update( int id, [FromBody] UpdateRoomCommandDto updateRoomCommandDto )
        {
            _roomUpdater.Update( id, updateRoomCommandDto.Map() );
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete( "{id}" )]
        public IActionResult Delete( int id )
        {
            _roomDeleter.Delete( id );
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete( "{roomId}/guests/{guestId}" )]
        public IActionResult RemoveGuest( int roomId, int guestId)
        {
            _roomService.RemoveGuest( roomId, guestId );

            _unitOfWork.Commit();

            return Ok();
        }
    }
}
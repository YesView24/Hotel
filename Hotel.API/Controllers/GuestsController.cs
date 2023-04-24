using Hotel.API.Dtos;
using Hotel.API.Mappers;
using Hotel.Application;
using Hotel.Application.Features.Guests.Commands.Creating;
using Hotel.Application.Features.Guests.Commands.Deleting;
using Hotel.Application.Features.Guests.Commands.Updating;
using Hotel.Application.Features.Guests.Queries.GetAllGuests;
using Hotel.Application.Features.Guests.Queries.GetGuestById;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route( "guests" )]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGetGuestByIdQueryHandler _getGuestByIdQueryHandler;
        private readonly IGetAllGuestsQueryHandler _getAllGuestQueryHandler;

        private readonly IGuestCreator _guestCreator;
        private readonly IGuestUpdater _guestUpdater;
        private readonly IGuestDeleter _guestDeleter;

        private readonly IUnitOfWork _unitOfWork;

        public GuestsController(
            IGetGuestByIdQueryHandler getGuestByIdQueryHandler,
            IGetAllGuestsQueryHandler getAllGuestQueryHandler,
            IGuestCreator guestCreator,
            IGuestUpdater guestUpdater,
            IGuestDeleter guestDeleter,
            IUnitOfWork unitOfWork )
        {
            _getGuestByIdQueryHandler = getGuestByIdQueryHandler;
            _getAllGuestQueryHandler = getAllGuestQueryHandler;
            _guestCreator = guestCreator;
            _guestUpdater = guestUpdater;
            _guestDeleter = guestDeleter;
            _unitOfWork = unitOfWork;
        }

        [HttpGet( "{id}" )]
        public IActionResult GetById( int id )
        {
            var guest = _getGuestByIdQueryHandler.Handle( id ).Map();

            return Ok( guest );
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var guests = _getAllGuestQueryHandler.Handle().Select( g => g.Map() );

            return Ok( guests );
        }

        [HttpPost]
        public IActionResult Add( [FromBody] AddGuestCommandDto addGuestCommandDto )
        {
            _guestCreator.Create( addGuestCommandDto.Map() );
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpPatch( "{id}" )]
        public IActionResult Update( int id, [FromBody] UpdateGuestCommandDto updateGuestCommandDto )
        {
            _guestUpdater.Update( id, updateGuestCommandDto.Map() );
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete( "{id}" )]
        public IActionResult Delete( int id )
        {
            _guestDeleter.Delete( id );
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
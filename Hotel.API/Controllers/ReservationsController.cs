using Hotel.API.Dtos;
using Hotel.API.Mappers;
using Hotel.Application;
using Hotel.Application.Features.Reservations.Commands.Creating;
using Hotel.Application.Features.Reservations.Commands.Deleting;
using Hotel.Application.Features.Reservations.Queries.GetAllReservations;
using Hotel.Application.Features.Reservations.Queries.GetReservationById;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route( "reservations" )]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IGetReservationByIdQueryHandler _getReservationByIdQueryHandler;
        private readonly IGetAllReservationsQueryHandler _getAllReservationQueryHandler;

        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationDeleter _reservationDeleter;

        private readonly IUnitOfWork _unitOfWork;

        public ReservationsController(
            IGetReservationByIdQueryHandler getReservationByIdQueryHandler,
            IGetAllReservationsQueryHandler getAllReservationQueryHandler,
            IReservationCreator reservationCreator,
            IReservationDeleter reservationDeleter,
            IUnitOfWork unitOfWork )
        {
            _getReservationByIdQueryHandler = getReservationByIdQueryHandler;
            _getAllReservationQueryHandler = getAllReservationQueryHandler;
            _reservationCreator = reservationCreator;
            _reservationDeleter = reservationDeleter;
            _unitOfWork = unitOfWork;
        }

        [HttpGet( "{id}" )]
        public IActionResult GetById( int id )
        {
            var reservation = _getReservationByIdQueryHandler.Handle( id ).Map();

            return Ok( reservation );
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _getAllReservationQueryHandler.Handle().Select( g => g.Map() );

            return Ok( reservations );
        }

        [HttpPost]
        public IActionResult Add( [FromBody] AddReservationCommandDto addReservationCommandDto )
        {
            _reservationCreator.Create( addReservationCommandDto.Map() );
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete( "{id}" )]
        public IActionResult Delete( int id )
        {
            _reservationDeleter.Delete( id );
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
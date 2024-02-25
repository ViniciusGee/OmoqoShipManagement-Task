using MediatR;
using Microsoft.AspNetCore.Mvc;
using Omoqo.Shared.Notifications;
using Omoqo.ShipManagement.Application.Ships.Commands;
using Omoqo.ShipManagement.Application.Ships.Services;
using Omoqo.ShipManagement.Domain.Ships.Models;
using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Omoqo.ShipManagement.Controllers.V1
{
    [SwaggerTag("Manage ships")] //TODO describe
    [Route("api/v1/")]
    [ApiController]
    public class ShipManagementController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IShipService _shipService;

        public ShipManagementController(IMediator mediator, IShipService shipService, INotifier notifier) : base(notifier)
        {
            _mediator = mediator;
            _shipService = shipService;
        }

        [HttpPost("create-ship")]
        [SwaggerOperation(Summary = "Creates a new ship.")]
        [ProducesResponseType(typeof(Ship), Status201Created)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateShip(CreateShipCommand request)
        {
            var shipCreated = await _mediator.Send(request);

            if (!IsValidOperation())
                return InvalidOperationResult();

            return Created($"{Request.Path.Value}/{shipCreated.Id}", shipCreated);
        }

        [HttpPut("update-ship/{shipId}")]
        [SwaggerOperation(Summary = "Updates a ship using Id.")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> UpdateShip(Guid shipId, UpdateShipCommand updatedShipRequest)
        {
            if (updatedShipRequest.Id == Guid.Empty || shipId != updatedShipRequest.Id)
                return BadRequest();

            await _mediator.Send(updatedShipRequest);

            if (!IsValidOperation())
                return InvalidOperationResult();

            return NoContent();
        }

        [HttpDelete("delete-ship/{Id:Guid}")]
        [SwaggerOperation(Summary = "Deletes a ship.")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> DeleteShip(Guid Id)
        {
            await _mediator.Send(new DeleteShipCommand(Id));

            if (!IsValidOperation())
                return InvalidOperationResult();

            return NoContent();
        }

        [HttpGet("all-ships")]
        [SwaggerOperation(Summary = "Get all ships.")]
        [ProducesResponseType(typeof(IEnumerable<Ship>), Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var allShips = await _shipService.GetAllShipsAsync();
            return Ok(allShips);
        }

        [HttpGet("get-ship/{Id:Guid}")]
        [SwaggerOperation(Summary = "Get a ships.")]
        [ProducesResponseType(typeof(Ship), Status200OK)]
        public async Task<IActionResult> GetShip(Guid Id)
        {
            var ship = await _shipService.GetShipAsync(Id);
            return Ok(ship);
        }

        //Docker
        //Unit
    }
}

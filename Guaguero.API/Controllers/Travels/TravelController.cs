using Guaguero.Application.DTOs.Travel;
using Guaguero.Application.Queries.Travels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guaguero.API.Controllers.Travels
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TravelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("TravelsInRouteAndWaypoint")]
        public async Task<ActionResult<IEnumerable<TravelResumeDTO>>> GetTravelsInRoute(GetTravelInRouteBeforeWaypointQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

    }
}

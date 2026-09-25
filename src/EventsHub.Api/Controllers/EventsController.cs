using EventsHub.Domain;
using Microsoft.AspNetCore.Mvc;
using EventsHub.Application.Events.Queries;
using EventsHub.Application.Events.Commands;

namespace EventsHub.Api.Controllers;

public class EventsController : EventsHubBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<Activity>), StatusCodes.Status200OK)]

    public async Task<ActionResult<IReadOnlyList<Activity>>> GetActivitiesAsync()
    {
        var activities = await Mediator.Send(new GetEventList.Query());

        return Ok(activities);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Activity), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Activity), StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id)
    {
        return await Mediator.Send(new GetEventDetails.Query { Id = id });
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<string>> CreateEventAsync(Activity @event)
    {
        return await Mediator.Send(new CreateEvent.Command { Event = @event });
    }

    [HttpPut]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]

    public async Task<ActionResult> EditEventAsync(Activity @event)
    {
        await Mediator.Send(new EditEvent.Command { Event = @event });
        return NoContent();
    }
}


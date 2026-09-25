using EventsHub.Domain; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsHub.Persistence;
using EventsHub.Application.Events.Queries;
using EventsHub.Application.Events.Commands;
using MediatR;

namespace EventsHub.Api.Controllers;

public class EventsController() : EventsHubBaseController
{

    [HttpGet]
    [producesResponseType(typeof(IReadOnlyList<Activity>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<Activity>>> GetActivitiesAsync()
    {
        return await Mediator.Send(new GetEventList.Query());
    }

    [HttpGet("{id}")]
    [producesResponseType(typeof(Activity), StatusCodes.Status200OK)]
    [producesResponseType(typeof(Activity), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id)
    {
        return await  Mediator.Send(new GetEventDetails.Query { Id = id });
    }

    [HttpPost]
    [producesResponseType(typeof(string), StatusCodes.Status200OK)]
    [producesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> CreateEventAsync(Activity @event)
    {
        return await Mediator.Send(new CreateEvent.Command { Event = @event });
    }
}
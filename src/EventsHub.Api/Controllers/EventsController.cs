using EventsHub.Domain; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsHub.Persistence;
using EventsHub.Application.Events.Queries;
using MediatR;

namespace EventsHub.Api.Controllers;

public class EventsController(IMediator mediator) : EventsHubBaseController
{

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Activity>>> GetActivitiesAsync()
    {
        return await mediator.Send(new GetEventList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id)
    {
        return await mediator.Send(new GetEventDetails.Query { Id = id });
    }
}
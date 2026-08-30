using EventsHub.Domain; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsHub.Persistence;

namespace EventsHub.Api.Controllers;

public class EventsController(AppDbContext context) : EventsHubBaseController
{

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Activity>>> GetActivitiesAsync()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id)
    {
        var result = await context.Activities.FindAsync(id);

        if (result == null) return NotFound("The event was not found");
        
        return result;
    }
}
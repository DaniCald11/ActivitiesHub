using Microsoft.AspNetCore.Mvc;
using MediatR;
namespace EventsHub.Api.Controllers;

[Route("api/v1/[controller]")] //ruta base
[ApiController] 

public class EventsHubBaseController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => 
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediatr service is unavailable. Ensure that MediatR is registered in the service collection.");


}
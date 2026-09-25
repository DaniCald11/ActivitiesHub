using EventsHub.Domain;
using EventsHub.Persistence;
using MediatR;
using Automapper;

namespace EventsHub.Application.Events.Commands;

public class EditEvent
{
    public class Command : IRequest
    {
        public Activity Event { get; set; }
    }

    public class Handler (AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var @event = await context.Activities
                    .FindAsync([request.Event.Id], cancellationToken)
                    ?? throw new Exception("Event not found");

                mapper.Map(request.Event, @event);

                await context.SaveChangesAsync(cancellationToken);
            }
        
    }
}
using EventsHub.Domain;
using EventsHub.Persistence;
using MediatR;

namespace EventsHub.Application.Events.Commands;

public class CreateEvent
{
    public class Command : IRequest<string>
    {
        public required Activity Event { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Activities.Add(request.Event);
            await context.SaveChangesAsync(cancellationToken);
            return request.Event.Id;
        }
    }
}

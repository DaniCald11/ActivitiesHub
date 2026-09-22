namespace EventsHub.Application.Events.Queries;
using EventsHub.Domain;
using EventsHub.Persistence;
using MediatR;

public class GetEventDetails
{
    public class Query : IRequest<Activity>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await context.Activities.FindAsync([request.Id], cancellationToken)
                        ?? throw new Exception("The activity was not found");

            return result;
        }
    }
}
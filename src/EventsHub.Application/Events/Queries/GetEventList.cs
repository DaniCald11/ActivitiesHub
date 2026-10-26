namespace EventsHub.Application.Events.Queries;
using EventsHub.Domain;
using EventsHub.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetEventList
{
    public class Query : IRequest<IReadOnlyList<Activity>>
    {
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, IReadOnlyList<Activity>>
    {
        public async Task<IReadOnlyList<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Activities.ToListAsync(cancellationToken);
        }
    }
}
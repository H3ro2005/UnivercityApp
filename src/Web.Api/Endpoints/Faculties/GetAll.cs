
using Application.Abstractions.Messaging;
using Application.Faculties.GetAll;
using Domain.Faculties.Responses;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Faculties;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("faculties", async (
            IQueryHandler<GetAllFacultiesQuery, 
            List<FacultyResponse>> handler, 
            CancellationToken cancellationToken) =>
            {
                var query = new GetAllFacultiesQuery();
                Result<List<FacultyResponse>> result = await handler.Handle(query, cancellationToken);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Faculties);
    }
}

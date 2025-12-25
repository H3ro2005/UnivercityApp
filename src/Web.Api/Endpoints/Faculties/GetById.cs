
using Application.Abstractions.Messaging;
using Application.Faculties.GetById;
using Domain.Faculties.Responses;
using Application.Todos.Get;
using Application.Todos.GetById;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Faculties;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("faculties/{id:guid}", async (
         Guid id,
         IQueryHandler<GetFacultyByIdQuery, FacultyResponse> handler,
         CancellationToken cancellationToken) =>
        {
            var query = new GetFacultyByIdQuery(id);

            Result<FacultyResponse> result = await handler.Handle(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
     .WithTags(Tags.Faculties);
    }
}

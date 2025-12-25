using Application.Abstractions.Messaging;
using Application.Faculties.Create;
using Application.Faculties.Delete;
using Application.Faculties.GetById;
using Domain.Faculties.Responses;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Faculties;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("faculties/{id:guid}", async (
         Guid id,
         ICommandHandler<DeleteFacultyCommand> handler,
         CancellationToken cancellationToken) =>
        {
            var command = new DeleteFacultyCommand(id);

            Result result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.NoContent, CustomResults.Problem);
        })
            .WithTags(Tags.Faculties);

    }
}

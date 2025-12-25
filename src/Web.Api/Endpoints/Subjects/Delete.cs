
using Application.Abstractions.Messaging;
using Application.Subjects.Delete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Subjects;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("subjects/{id:guid}", async (
            Guid id,
            ICommandHandler<DeleteSubjectCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteSubjectCommand(id);
            Result result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.NoContent, CustomResults.Problem);
        }).WithTags(Tags.Subjectas);
    }
}


using Application.Abstractions.Messaging;
using Application.Faculties.Class.Delete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Faculties.Classes;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("faculties/{facultyId:guid}/classes/{classid:guid}", async (Guid facultyId, Guid classid, ICommandHandler<DeleteClassCommand> handler, CancellationToken cancellationToken) =>
        {
            var command = new DeleteClassCommand(facultyId, classid);
            Result result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Classes);
    }
}

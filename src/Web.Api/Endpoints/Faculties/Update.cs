
using Application.Abstractions.Messaging;
using Application.Faculties.Update;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Faculties;

internal sealed class Update : IEndpoint
{
    public sealed class Request
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("faculties/{id:guid}", async (
            Guid id,
            Request request,
            ICommandHandler<UpdateFacultyCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateFacultyCommand(id, request.Name, request.Description);
            Result result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.NoContent, CustomResults.Problem);
        }).WithTags(Tags.Faculties);
    }
}

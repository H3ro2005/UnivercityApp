using Application.Abstractions.Messaging;
using Application.Faculties.Class.Update;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;


namespace Web.Api.Endpoints.Faculties.Classes;

internal sealed class Update : IEndpoint
{
    public sealed class Request
    {
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public int grade { get; set; }
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("faculties/{facultyid:guid}/classes/{id:guid}", async (
            Guid facultyid,
            Guid id,
            Request request,
            ICommandHandler<UpdateClassCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateClassCommand()
            {
                FacultyId = facultyid,
                ClassId = id,
                Name = request.Name,
                Grade = request.grade,
                IsOnline = request.IsOnline
            };
               
            Result result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.NoContent, CustomResults.Problem);
        }).WithTags(Tags.Classes);
    }
}

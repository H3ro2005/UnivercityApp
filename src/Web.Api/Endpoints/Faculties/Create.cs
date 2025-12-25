
using Application.Abstractions.Messaging;
using Application.Faculties.Class.Add;
using Application.Faculties.Create;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Faculties;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? EmployeeId { get; set; }
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("faculties", async (Request request, ICommandHandler<CreateFacultyCommand, Guid> handler, CancellationToken cancellationToken) =>
            {
                var command = new CreateFacultyCommand
                {
                    EmployeeId = request.EmployeeId,
                    Name = request.Name,
                    Description = request.Description
                };

                Result<Guid> result = await handler.Handle(command, cancellationToken);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Faculties);
            
    }
}

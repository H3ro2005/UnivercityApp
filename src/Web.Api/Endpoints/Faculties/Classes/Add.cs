
using Application.Abstractions.Messaging;
using Application.Faculties.Class.Add;
using Application.Faculties.Create;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Faculties.Classes;

internal sealed class Add : IEndpoint
{
    public sealed class Request
    {
        public bool IsOnline { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }  
    }
   
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("faculties/{id:guid}/classes", async (Guid id,Request request, ICommandHandler<AddClassCommand, Guid> handler, CancellationToken cancellationToken) =>
        {
            var command = new AddClassCommand
            {
                FacultyId = id,
                IsOnline = request.IsOnline,
                Name = request.Name,
                Grade = request.Grade,
            };

            Result<Guid> result = await handler.Handle(command, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
            .WithTags(Tags.Classes);

    }
}



using Application.Abstractions.Messaging;
using Application.Subjects.Create;
using Domain.Subjects;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Subjects;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public string Name { get; set; }
        public Category Category { get; set; }
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("subjects", async (Request request, ICommandHandler<CreateSubjectCommand, Guid> handler, CancellationToken cancellationToken) =>
            {
                var command = new CreateSubjectCommand
                {
                    Name = request.Name,
                    Category = request.Category
                };
                Result<Guid> result = await handler.Handle(command, cancellationToken);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Subjectas);
           
    }
}

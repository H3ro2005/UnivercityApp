using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Subjects;
using SharedKernel;

namespace Application.Subjects.Create;
internal sealed class CreateSubjectCommandHandler(IApplicationDbContext context) : ICommandHandler<CreateSubjectCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateSubjectCommand command, CancellationToken cancellationToken)
    {
        var subject = Subject.Create(
            command.Name,
            command.Category);


        context.Subjects.Add(subject);
        await context.SaveChangesAsync(cancellationToken);
        return subject.Id;
    }
}

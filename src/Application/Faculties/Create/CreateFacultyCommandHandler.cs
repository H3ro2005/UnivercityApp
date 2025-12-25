using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties;
using Domain.Faculties.DomainEvents;
using SharedKernel;

namespace Application.Faculties.Create;
internal sealed class CreateFacultyCommandHandler(IApplicationDbContext context,
    IDateTimeProvider dateTimeProvider) : ICommandHandler<CreateFacultyCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateFacultyCommand command, CancellationToken cancellationToken)
    {
        var faculty = Faculty.Create(
            command.EmployeeId,
            command.Name,
            command.Description, 
            dateTimeProvider.UtcNow);

        faculty.Raise(new FacultyCreatedDomainEvent(faculty.Id));
        context.Faculties.Add(faculty);
        await context.SaveChangesAsync(cancellationToken);
        return faculty.Id;
    }
}

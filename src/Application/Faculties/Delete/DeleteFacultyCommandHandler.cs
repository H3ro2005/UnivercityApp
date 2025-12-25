using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties;
using Domain.Faculties.DomainEvents;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Faculties.Delete;
internal sealed class DeleteFacultyCommandHandler(IApplicationDbContext _context) : ICommandHandler<DeleteFacultyCommand>
{
    public async Task<Result> Handle(DeleteFacultyCommand command, CancellationToken cancellationToken)
    {
        Faculty? faculty = await _context.Faculties.SingleOrDefaultAsync(f => f.Id == command.FacultyId, cancellationToken);
        if (faculty is null)
        {
            return Result.Failure(FacultyErrors.NotFound(command.FacultyId));
        }
        _context.Faculties.Remove(faculty);

        faculty.Raise(new FacultyDeletedDomainEvent(faculty.Id));
        await _context.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Subjects;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Subjects.Delete;
internal sealed class DeleteSubjectCommandHandler(IApplicationDbContext _context) : ICommandHandler<DeleteSubjectCommand>
{
    public async Task<Result> Handle(DeleteSubjectCommand command, CancellationToken cancellationToken)
    {
        Subject? subject = await _context.Subjects.SingleOrDefaultAsync(f => f.Id == command.SubjectId, cancellationToken);
        if (subject is null)
        {
            return Result.Failure(SubjectErrors.NotFound(command.SubjectId));
        }
      

        subject.Raise(new SubjectDeletedDomainEvent(subject.Id));

        _context.Subjects.Remove(subject);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}

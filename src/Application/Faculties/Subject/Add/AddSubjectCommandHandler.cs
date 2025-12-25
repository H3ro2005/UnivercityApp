using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties;
using Domain.Faculties.Repositories;
using SharedKernel;

namespace Application.Faculties.Subject.Add;
internal sealed class AddSubjectCommandHandler(IApplicationDbContext _context, IClassRepository _subject) : ICommandHandler<AddSubjectCommand>
{
    public async Task<Result> Handle(AddSubjectCommand command, CancellationToken cancellationToken)
    {
        await _subject.AddSubjectAsync(command.FacultyId, command.SubjectId, command.Semester, command.Grade, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}

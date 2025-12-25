using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Domain.Subjects;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Subjects.Delete;
internal sealed class SubjectDeletedDomainEventHandler(IApplicationDbContext _context) : IDomainEventHandler<SubjectDeletedDomainEvent>
{
    public async Task Handle(SubjectDeletedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        await _context.FacultyUsedSubjects.Where(s => s.Id == domainEvent.subjectid)
            .ExecuteDeleteAsync(cancellationToken);
    }
}

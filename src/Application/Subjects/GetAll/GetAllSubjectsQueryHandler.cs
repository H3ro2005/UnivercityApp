using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Subjects.Responses;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Subjects.GetAll;
internal sealed class GetAllSubjectsQueryHandler(IApplicationDbContext _context) : IQueryHandler<GetAllSubjectsQuery, List<SubjectResponse>>
{
    public async Task<Result<List<SubjectResponse>>> Handle(GetAllSubjectsQuery query, CancellationToken cancellationToken)
    {
        List<SubjectResponse> subjects = await _context.Subjects
            .AsNoTracking()
            .Select(f => new SubjectResponse(
            f.Id,
            f.Name,
            f.Category
            )).ToListAsync(cancellationToken);

        return subjects;
    }
}

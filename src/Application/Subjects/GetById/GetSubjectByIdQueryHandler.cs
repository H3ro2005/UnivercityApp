using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Subjects.Responses;
using Domain.Subjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Subjects.GetById;
internal sealed class GetSubjectByIdQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetSubjectByIdQuery, SubjectResponse>
{
    public async Task<Result<SubjectResponse>> Handle(GetSubjectByIdQuery query, CancellationToken cancellationToken)
    {
            SubjectResponse? subject = await context.Subjects
            .AsNoTracking()
            .Where(f => f.Id == query.SubjectId)
            .Select(f => new SubjectResponse
            (
                f.Id,
                f.Name,
                f.Category
                
            ))
            .SingleOrDefaultAsync(cancellationToken);

        if (subject is null)
        {
            return Result.Failure<SubjectResponse>(SubjectErrors.NotFound(query.SubjectId));
        }

        return subject;
    }
}

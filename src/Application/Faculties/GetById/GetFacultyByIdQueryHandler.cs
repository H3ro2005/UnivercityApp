using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties.Responses;
using Domain.Faculties;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Faculties.GetById;
internal sealed class GetFacultyByIdQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetFacultyByIdQuery, FacultyResponse>
{
    public async Task<Result<FacultyResponse>> Handle(GetFacultyByIdQuery query, CancellationToken cancellationToken)
    {
            FacultyResponse? faculty = await context.Faculties
            .AsNoTracking()
            .Where(f => f.Id == query.FacultyId)
            .Select(f => new FacultyResponse
            {
                Id = f.Id,
                EmployeeId = f.EmployeeId,
                DeletedAt = f.DeletedAt,
                Name = f.Name,
                Description = f.Description,
                CreatedAt = f.CreatedAt,
                
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (faculty is null)
        {
            return Result.Failure<FacultyResponse>(FacultyErrors.NotFound(query.FacultyId));
        }

        return faculty;
    }
}

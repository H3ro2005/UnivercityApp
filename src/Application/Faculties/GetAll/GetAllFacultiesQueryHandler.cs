using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties.Responses;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Faculties.GetAll;
internal sealed class GetAllFacultiesQueryHandler(IApplicationDbContext _context) : IQueryHandler<GetAllFacultiesQuery, List<FacultyResponse>>
{
    public async Task<Result<List<FacultyResponse>>> Handle(GetAllFacultiesQuery query, CancellationToken cancellationToken)
    {
        List<FacultyResponse> faculties = await _context.Faculties
            .AsNoTracking()
            .Select(f => new FacultyResponse
        {
            Id = f.Id,
            EmployeeId = f.EmployeeId,
            DeletedAt = f.DeletedAt,
            Name = f.Name,
            Description = f.Description,
            CreatedAt = f.CreatedAt,

        }).ToListAsync(cancellationToken);

        return faculties;
    }
}

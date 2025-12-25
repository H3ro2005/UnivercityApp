using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Faculties.GetAllInfo;
internal sealed class GetAllInfoFacultiesQueryHandler(IApplicationDbContext _context) : IQueryHandler<GetAllInfoFacultiesQuery, List<Faculty>>
{
    public async Task<Result<List<Faculty>>> Handle(GetAllInfoFacultiesQuery query, CancellationToken cancellationToken)
    {
      List<Faculty> faculties = await _context.Faculties
            .AsNoTracking()  
            .Include(f => f.Classes)
            .Include(f => f.Subjects)
            .ToListAsync(cancellationToken);

        return faculties;

    }
}

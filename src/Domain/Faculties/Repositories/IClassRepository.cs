using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Faculties.Responses;
using SharedKernel;

namespace Domain.Faculties.Repositories;
public interface IClassRepository
{
    Task<Result<Guid>> AddClassAsync(Guid FacultyId, string Name, int Grade, bool IsOnline, CancellationToken cancellationToken);

    Task<Result> DeleteClassAsync(Guid FacultyId, Guid ClassId, CancellationToken cancellationToken);

    Task<Result> UpdateClassAsync(Guid FacultyId, Guid ClassId, string Name, int Grade, bool IsOnline, CancellationToken cancellationToken);

    Task<Result> AddSubjectAsync (Guid FacultyId, Guid SubjectId, int Semester, int Grade, CancellationToken cancellationToken);


}



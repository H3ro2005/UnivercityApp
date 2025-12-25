
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Faculties;
using Domain.Faculties.Repositories;
using Domain.Faculties.Responses;
using Domain.Subjects;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedKernel;

namespace Infrastructure.Faculties.Repositories;
internal sealed class ClassRepository : IClassRepository
{
    private readonly ApplicationDbContext _context;

    public ClassRepository(ApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<Result<Guid>> AddClassAsync(Guid FacultyId,string Name,int Grade,bool IsOnline, CancellationToken cancellationToken)
    {
        Faculty? faculty = await _context.Faculties.Include(x=> x.Classes).SingleOrDefaultAsync(f => f.Id == FacultyId, cancellationToken);
        if (faculty is null)
        {
            return Result.Failure<Guid>(FacultyErrors.NotFound(FacultyId));
        }
        Class @class = faculty.AddClass(Name, Grade, IsOnline, faculty.Id);
        _context.Entry(@class).State = EntityState.Added;

        return @class.Id;
    }

    public async Task<Result> AddSubjectAsync(Guid FacultyId, Guid SubjectId, int Semester, int Grade, CancellationToken cancellationToken)
    {
        Subject? subject = await _context.Subjects.SingleOrDefaultAsync(s => s.Id == SubjectId, cancellationToken);

        Faculty? faculty = await _context.Faculties.SingleOrDefaultAsync(f => f.Id == FacultyId, cancellationToken);
        if (subject is null)
        {
            return Result.Failure(SubjectErrors.NotFound(SubjectId));
        }
        if (faculty is null)
        {
            return Result.Failure(FacultyErrors.NotFound(FacultyId));
        }
        FacultyUsedSubject usedsubject = faculty.AddClassSubject(SubjectId,subject.Name,subject.Category, Semester, Grade,FacultyId);
        _context.Entry(usedsubject).State = EntityState.Added;

        return Result.Success();

    }

    public async Task<Result> DeleteClassAsync(Guid FacultyId, Guid ClassId, CancellationToken cancellationToken)
    {
        Faculty? faculty = await _context.Faculties.Include(x => x.Classes.Where(x=>x.Id==ClassId)).SingleOrDefaultAsync(f => f.Id == FacultyId, cancellationToken);
        if (faculty is null)
        {
            return Result.Failure(FacultyErrors.NotFound(FacultyId));
        }
        if (faculty.Classes.Count == 0)
        {
            return Result.Failure(FacultyErrors.NotFound(FacultyId));
        }
        faculty.DeleteClass(faculty.Classes[0]);
    
        //_context.Entry(@class).State = EntityState.Deleted;
        return Result.Success();
    }

    public async Task<Result> UpdateClassAsync(Guid FacultyId, Guid ClassId, string Name, int Grade, bool IsOnline, CancellationToken cancellationToken)
    {
        Faculty? faculty = await _context.Faculties.Include(x => x.Classes.Where(x => x.Id == ClassId)).SingleOrDefaultAsync(f => f.Id == FacultyId, cancellationToken);
        if (faculty is null)
        {
            return Result.Failure(FacultyErrors.NotFound(FacultyId));
        }
        if (faculty.Classes.Count == 0)
        {
            return Result.Failure(FacultyErrors.NotFound(FacultyId));
        }
        faculty.UpdateClass(Name, Grade, IsOnline);

        return Result.Success();
    }
}

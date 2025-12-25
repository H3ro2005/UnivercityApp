using Domain.Faculties;
using Domain.Subjects;
using Domain.Todos;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Faculty> Faculties { get; }
    DbSet<Subject> Subjects { get; }
    DbSet<FacultyUsedSubject> FacultyUsedSubjects { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

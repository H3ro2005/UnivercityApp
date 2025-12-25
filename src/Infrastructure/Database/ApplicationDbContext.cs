using Application.Abstractions.Data;
using Domain.Faculties;
using Domain.Subjects;
using Domain.Todos;
using Domain.Users;
using Infrastructure.DomainEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedKernel;

namespace Infrastructure.Database;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    IDomainEventsDispatcher domainEventsDispatcher)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<TodoItem> TodoItems { get; set; }

    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Class> Classes { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<FacultyUsedSubject> FacultyUsedSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
        
       
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // When should you publish domain events?
        //
        // 1. BEFORE calling SaveChangesAsync
        //     - domain events are part of the same transaction
        //     - immediate consistency
        // 2. AFTER calling SaveChangesAsync
        //     - domain events are a separate transaction
        //     - eventual consistency
        //     - handlers can fail

        var domainEvents = ChangeTracker
  .Entries<Entity>()
  .Select(entry => entry.Entity)
  .SelectMany(entity =>
  {
      List<IDomainEvent> domainEvents = entity.DomainEvents;

      entity.ClearDomainEvents();

      return domainEvents;
  })
  .ToList();

        int result = await base.SaveChangesAsync(cancellationToken);



        await domainEventsDispatcher.DispatchAsync(domainEvents, cancellationToken);

        return result;
    }


}

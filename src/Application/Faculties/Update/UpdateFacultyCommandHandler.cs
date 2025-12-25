using System.Threading.Tasks;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Faculties.Update;
internal sealed class UpdateFacultyCommandHandler(IApplicationDbContext _context) : ICommandHandler<UpdateFacultyCommand>
{
    public async Task<Result> Handle(UpdateFacultyCommand command, CancellationToken cancellationToken)
    {
     
        Faculty faculty = await _context.Faculties.SingleOrDefaultAsync(f => f.Id == command.FacultyId, cancellationToken);
        if (faculty is null)
        {
            return Result.Failure(FacultyErrors.NotFound(command.FacultyId));
        }
        faculty.Update(command.Name,command.Description);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}

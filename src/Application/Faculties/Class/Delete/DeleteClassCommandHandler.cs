using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties.Repositories;
using SharedKernel;

namespace Application.Faculties.Class.Delete;
internal sealed class DeleteClassCommandHandler(IApplicationDbContext _context,IClassRepository _repo) : ICommandHandler<DeleteClassCommand>
{
    public async Task<Result> Handle(DeleteClassCommand command, CancellationToken cancellationToken)
    {
        Result result = await _repo.DeleteClassAsync(command.FacultyId, command.ClassId, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties.Repositories;
using SharedKernel;

namespace Application.Faculties.Class.Update;
internal sealed class UpdateClassCommandHandler(IApplicationDbContext _context, IClassRepository _repo) : ICommandHandler<UpdateClassCommand>
{
    public async Task<Result> Handle(UpdateClassCommand command, CancellationToken cancellationToken)
    {
        Result result = await _repo.UpdateClassAsync(command.FacultyId, command.ClassId, command.Name, command.Grade, command.IsOnline, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }
}

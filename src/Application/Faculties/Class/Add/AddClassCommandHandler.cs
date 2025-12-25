using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Faculties.Responses;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using Domain.Faculties.Repositories;


namespace Application.Faculties.Class.Add;
internal sealed class AddClassCommandHandler(IApplicationDbContext _context,IClassRepository _faculty) : ICommandHandler<AddClassCommand, Guid>
{
    public async Task<Result<Guid>> Handle(AddClassCommand command, CancellationToken cancellationToken)
    {
       Result<Guid> id = await _faculty.AddClassAsync(command.FacultyId, command.Name, command.Grade, command.IsOnline,cancellationToken);


        await _context.SaveChangesAsync(cancellationToken);
        return id;
    }
}

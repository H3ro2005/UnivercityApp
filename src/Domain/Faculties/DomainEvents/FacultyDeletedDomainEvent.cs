using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.Faculties.DomainEvents;
public sealed record FacultyDeletedDomainEvent(Guid id) : IDomainEvent
{
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.Subjects;
public sealed record SubjectDeletedDomainEvent(Guid subjectid) : IDomainEvent;



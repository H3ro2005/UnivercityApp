using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Faculties;
public sealed record SubjectTeacher(Guid SubjectId,Guid TeacherId);

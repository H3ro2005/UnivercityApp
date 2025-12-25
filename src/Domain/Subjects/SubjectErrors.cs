using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;


namespace Domain.Subjects;
public static class SubjectErrors
{
    public static Error NotFound(Guid subjectId) => Error.NotFound(
       "Faculties.NotFound",
       $"The subject with the Id = '{subjectId}' was not found");
}

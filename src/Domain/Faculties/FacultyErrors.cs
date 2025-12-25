using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.Faculties;
public static class FacultyErrors
{
    public static Error NotFound(Guid facultyId) => Error.NotFound(
       "Faculties.NotFound",
       $"The faculty with the Id = '{facultyId}' was not found");
}

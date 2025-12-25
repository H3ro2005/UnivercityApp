using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Faculties.Subject.Add;
public sealed class AddSubjectCommand : ICommand
{
    public Guid FacultyId { get; set; }
    public Guid SubjectId { get; set; }
    public int Semester { get; set; }
    public int Grade { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.Faculties;
public sealed class Class : Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }

    public int Grade { get; private set; }

    public bool IsOnline { get; private set; }

    public Guid FacultyId { get; private set; }

    //private readonly List<Guid> _studentIds = new List<Guid>();

    //public IReadOnlyList<Guid> StudentIds => _studentIds.AsReadOnly();

    //private readonly List<SubjectTeacher> _subjectTeacherConnectorIds = new List<SubjectTeacher>();

    //public IReadOnlyList<SubjectTeacher> SubjectTeacherConnectorIds => _subjectTeacherConnectorIds.AsReadOnly();

    private Class()
    {
    }
    
    public static Class Create(string name,int grade,bool isOnline,Guid facultyid)
    {
        return new Class()
        {
            Name = name,
            Grade = grade,
            IsOnline = isOnline,
            FacultyId = facultyid

        };
    }


    public void UpdateClass(string name, int grade, bool isOnline)
    {
        Name = name;
        Grade = grade;
        IsOnline = isOnline;
    }
}

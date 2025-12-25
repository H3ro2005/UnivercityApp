using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Subjects;
using SharedKernel;

namespace Domain.Faculties;
public sealed class FacultyUsedSubject : Entity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Category Category { get; private set; }

    public int Grade { get; private set; }

    public int Semester { get; private set; }

    public Guid FacultyId { get; private set; }

    private FacultyUsedSubject()
    {

    }

    public static FacultyUsedSubject Assign(Guid id, string name, Category category, int semester, int grade,Guid facultyid)
    {
        return new FacultyUsedSubject()
        {
            Id = id,
            Name = name,
            Category = category,           
            Grade = grade,
            Semester = semester,
            FacultyId = facultyid
        };
    }

    internal void UpdateSubject(int semester, int grade)
    {
        Semester = semester;
        Grade = grade;
    }
}

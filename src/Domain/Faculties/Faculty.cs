using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Subjects;
using SharedKernel;

namespace Domain.Faculties;
public sealed class Faculty : Entity
{
    public Guid Id { get;  private set; }
    public Guid? EmployeeId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public IReadOnlyList<Class> Classes => _classes.AsReadOnly();


    private readonly List<Class> _classes = new();

    public IReadOnlyList<FacultyUsedSubject> Subjects => _subjects.AsReadOnly();


    private readonly List<FacultyUsedSubject> _subjects = new();
    private Faculty()
    { 
    
    }



    public void Update(string name,string description)
    {
        Name = name;
        Description = description;
    }
    public static Faculty Create(Guid? employeeId, string name, string description,DateTime date)
    {    
        return new Faculty
        {
            Id = Guid.NewGuid(),
            EmployeeId = employeeId,
            Name = name,
            Description = description,
            CreatedAt = date,
            DeletedAt = null    
        };
    }

    //Classes

    public Class AddClass(string name, int grade, bool isOnline,Guid facultyid)
    {
        var @class = Class.Create(name, grade, isOnline, facultyid);
       
        _classes.Add(@class);
     
        return @class;

    }

    public void DeleteClass(Class @class)
    {
        _classes.Remove(@class);
        
    }

    public void UpdateClass(string name, int grade, bool isOnline)
    {
        Class value = _classes[0];
        value.UpdateClass(name, grade, isOnline);
    }

    //Subjects

    public FacultyUsedSubject AddClassSubject(Guid subjectId, string name, Category category, int semester, int grade,Guid facultyid)
    {
        var subject = FacultyUsedSubject.Assign(subjectId,name,category,semester,grade,facultyid);

        _subjects.Add(subject);

        return subject;

    }

    public void DeleteSubject(FacultyUsedSubject subject)
    {
        _subjects.Remove(subject);

    }

    public void UpdateSubject(int semester , int grade)
    {
        FacultyUsedSubject value = _subjects[0];
        value.UpdateSubject(semester,grade);
    }
}


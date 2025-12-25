using Application.Abstractions.Messaging;

namespace Application.Faculties.Create;
public sealed class  CreateFacultyCommand() : ICommand<Guid>
{
    public Guid? EmployeeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}

using Application.Abstractions.Messaging;
using Domain.Subjects;

namespace Application.Subjects.Create;
public sealed class CreateSubjectCommand() : ICommand<Guid>
{
    public string Name { get; set; }

    public Category Category { get; set; }
}

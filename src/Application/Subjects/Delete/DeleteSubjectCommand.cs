using Application.Abstractions.Messaging;

namespace Application.Subjects.Delete;
public sealed record DeleteSubjectCommand(Guid SubjectId) : ICommand;


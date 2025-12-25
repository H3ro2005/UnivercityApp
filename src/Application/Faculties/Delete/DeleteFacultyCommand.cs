using Application.Abstractions.Messaging;

namespace Application.Faculties.Delete;
public sealed record DeleteFacultyCommand(Guid FacultyId) : ICommand;


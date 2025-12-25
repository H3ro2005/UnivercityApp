using Application.Abstractions.Messaging;

namespace Application.Faculties.Update;
public sealed record UpdateFacultyCommand(Guid FacultyId,string Name,string Description):ICommand;

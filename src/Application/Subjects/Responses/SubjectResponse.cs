using Domain.Subjects;

namespace Application.Subjects.Responses;
public sealed record SubjectResponse(Guid Id, string Name,Category Category);

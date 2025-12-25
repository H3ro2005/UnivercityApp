using Application.Abstractions.Messaging;
using Application.Subjects.Responses;

namespace Application.Subjects.GetById;
public sealed record GetSubjectByIdQuery(Guid SubjectId) : IQuery<SubjectResponse>;



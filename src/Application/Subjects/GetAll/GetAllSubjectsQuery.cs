using Application.Abstractions.Messaging;
using Application.Subjects.Responses;

namespace Application.Subjects.GetAll;
public sealed class GetAllSubjectsQuery:IQuery<List<SubjectResponse>>;


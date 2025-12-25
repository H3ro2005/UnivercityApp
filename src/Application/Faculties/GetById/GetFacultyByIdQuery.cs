using Application.Abstractions.Messaging;
using Domain.Faculties.Responses;

namespace Application.Faculties.GetById;
public sealed record GetFacultyByIdQuery(Guid FacultyId) : IQuery<FacultyResponse>;



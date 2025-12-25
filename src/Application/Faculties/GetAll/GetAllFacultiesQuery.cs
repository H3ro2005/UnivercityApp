using Application.Abstractions.Messaging;
using Domain.Faculties.Responses;

namespace Application.Faculties.GetAll;
public sealed class GetAllFacultiesQuery:IQuery<List<FacultyResponse>>;


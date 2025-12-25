using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Faculties;

namespace Application.Faculties.GetAllInfo;
public sealed record GetAllInfoFacultiesQuery : IQuery<List<Faculty>>
{
}

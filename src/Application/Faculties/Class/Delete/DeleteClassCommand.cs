using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Faculties.Class.Delete;
public sealed record DeleteClassCommand(Guid FacultyId,Guid ClassId):ICommand;


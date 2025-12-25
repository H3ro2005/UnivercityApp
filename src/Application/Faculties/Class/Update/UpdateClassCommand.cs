using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Faculties.Class.Update;
public sealed class UpdateClassCommand:ICommand
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public bool IsOnline { get; set; }
    public Guid FacultyId { get; set; }
    public Guid ClassId { get; set; }
}

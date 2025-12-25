using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Faculties.Class.Add;
public sealed class AddClassCommand :ICommand<Guid>
{
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
     public int Grade { get; set; }
    public bool IsOnline { get; set; }

}

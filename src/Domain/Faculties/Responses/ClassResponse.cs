using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Faculties.Responses;
public sealed class ClassResponse
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public bool IsOnline { get; set; }
}

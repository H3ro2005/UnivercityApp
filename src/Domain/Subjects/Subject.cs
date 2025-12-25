using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.Subjects;
public sealed class Subject : Entity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Category Category { get; private set; }

    private Subject()
    {

    }

    public static Subject Create(string name, Category category = Category.None)
    {
        return new Subject()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Category = category

        };
    }
}

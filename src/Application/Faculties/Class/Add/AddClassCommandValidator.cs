using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Faculties.Class.Add;
internal sealed class AddClassCommandValidator:AbstractValidator<AddClassCommand>
{
    public AddClassCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

                RuleFor(x => x.Grade).NotEmpty();

        RuleFor(x => x.IsOnline)
            .NotNull();
        RuleFor(x => x.FacultyId)
            .NotEmpty();
    }
}

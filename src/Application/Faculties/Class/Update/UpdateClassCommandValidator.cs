using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Faculties.Class.Update;
internal sealed class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
{
    public UpdateClassCommandValidator()
    {
     
        
        RuleFor(x => x.Name)
           .NotEmpty()
           .MaximumLength(50);

        RuleFor(x => x.Grade).NotEmpty();

        RuleFor(x => x.IsOnline)
            .NotNull();
        RuleFor(x => x.FacultyId)
            .NotEmpty();
        RuleFor(x => x.FacultyId)
           .NotEmpty();
    }
}

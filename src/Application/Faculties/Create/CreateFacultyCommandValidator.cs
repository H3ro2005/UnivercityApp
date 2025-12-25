using FluentValidation;

namespace Application.Faculties.Create;
internal sealed class CreateFacultyCommandValidator:AbstractValidator<CreateFacultyCommand>
{
    public CreateFacultyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(256);


    }
}

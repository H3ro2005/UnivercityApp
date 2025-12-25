using FluentValidation;

namespace Application.Subjects.Create;
internal sealed class CreateFacultyCommandValidator:AbstractValidator<CreateSubjectCommand>
{
    public CreateFacultyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Category).NotEmpty();


    }
}

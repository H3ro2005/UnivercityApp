using FluentValidation;

namespace Application.Faculties.Delete;
internal sealed class DeleteFacultyCommandValidator:AbstractValidator<DeleteFacultyCommand>
{
    public DeleteFacultyCommandValidator()
    {
        RuleFor(x => x.FacultyId).NotEmpty();
    }
}

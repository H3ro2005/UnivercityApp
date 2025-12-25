using FluentValidation;

namespace Application.Subjects.Delete;
internal sealed class DeleteSubjectCommandValidator:AbstractValidator<DeleteSubjectCommand>
{
    public DeleteSubjectCommandValidator()
    {
        RuleFor(x => x.SubjectId).NotEmpty();
    }
}

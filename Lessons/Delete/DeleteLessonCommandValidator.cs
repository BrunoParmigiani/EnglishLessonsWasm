using FluentValidation;

namespace EnglishLessonsWasm.Lessons.Delete;

public sealed class DeleteLessonCommandValidator : AbstractValidator<DeleteLessonCommand>
{
    public DeleteLessonCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");
    }
}

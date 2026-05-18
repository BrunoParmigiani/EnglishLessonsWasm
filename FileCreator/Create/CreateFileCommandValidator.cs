using EnglishLessonsWasm.Lessons.DTO;
using FluentValidation;

namespace EnglishLessonsWasm.FileCreator.Create;

public sealed class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
{
    public CreateFileCommandValidator()
    {
        RuleFor(property => property.Lesson)
            .SetValidator(new LessonDTOValidator());

        RuleFor(property => property.Strategy)
            .NotNull()
            .WithMessage("Strategy cannot be null");
    }
}

using FluentValidation;

namespace EnglishLessonsWasm.Lessons.Create;

public sealed class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(command => command.Number)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Lesson number cannot be lower than 1");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateLessonCommand>.CreateWithOptions((CreateLessonCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

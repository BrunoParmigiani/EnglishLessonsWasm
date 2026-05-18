using EnglishLessonsWasm.Lessons.DTO;
using FluentValidation;

namespace EnglishLessonsWasm.Lessons.Update;

public sealed class UpdateLessonCommandValidator : AbstractValidator<UpdateLessonCommand>
{
    public UpdateLessonCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");

        RuleFor(command => command.Number)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Lesson number cannot be lower than 1");

        RuleFor(command => command.Verbs)
            .NotNull()
            .WithMessage("Verbs cannot be null");

        RuleForEach(command => command.Verbs)
            .SetValidator(new WordDTOValidator());

        RuleFor(command => command.Words)
            .NotNull()
            .WithMessage("Words cannot be null");

        RuleForEach(command => command.Words)
            .SetValidator(new WordDTOValidator());

        RuleFor(command => command.Expressions)
            .NotNull()
            .WithMessage("Expressions cannot be null");

        RuleForEach(command => command.Expressions)
            .SetValidator(new WordDTOValidator());
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateLessonCommand>.CreateWithOptions((UpdateLessonCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

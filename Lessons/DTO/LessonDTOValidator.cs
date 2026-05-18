using FluentValidation;

namespace EnglishLessonsWasm.Lessons.DTO;
public sealed class LessonDTOValidator : AbstractValidator<LessonDTO>
{
    public LessonDTOValidator()
    {
        RuleFor(property => property.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");

        RuleFor(property => property.Number)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Number cannot be lower than 1");

        RuleFor(property => property.Verbs)
            .NotNull()
            .WithMessage("Verbs cannot be null");

        RuleFor(property => property.Words)
            .NotNull()
            .WithMessage("Words cannot be null");

        RuleFor(property => property.Expressions)
            .NotNull()
            .WithMessage("Expressions cannot be null");

        RuleForEach(property => property.Verbs)
            .SetValidator(new WordDTOValidator());

        RuleForEach(property => property.Words)
            .SetValidator(new WordDTOValidator());

        RuleForEach(property => property.Expressions)
            .SetValidator(new WordDTOValidator());
    }
}

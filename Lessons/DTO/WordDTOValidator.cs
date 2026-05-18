using FluentValidation;

namespace EnglishLessonsWasm.Lessons.DTO;
public sealed class WordDTOValidator : AbstractValidator<WordDTO>
{
    public WordDTOValidator()
    {
        RuleFor(property => property.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<WordDTO>.CreateWithOptions((WordDTO)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

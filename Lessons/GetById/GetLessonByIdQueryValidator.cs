using FluentValidation;

namespace EnglishLessonsWasm.Lessons.GetById;

public sealed class GetLessonByIdQueryValidator : AbstractValidator<GetLessonByIdQuery>
{
    public GetLessonByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");
    }
}

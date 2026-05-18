using FluentValidation;
using MediatR;

namespace EnglishLessonsWasm.Lessons.Delete;

public sealed class DeleteLessonHandler : IRequestHandler<DeleteLessonCommand>
{
    private readonly ILessonsData _data;
    private readonly DeleteLessonCommandValidator _validator;

    public DeleteLessonHandler(ILessonsData data, DeleteLessonCommandValidator validator)
    {
        _data = data;
        _validator = validator;
    }

    public Task Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        _data.Delete(request.Id);

        return Task.CompletedTask;
    }
}

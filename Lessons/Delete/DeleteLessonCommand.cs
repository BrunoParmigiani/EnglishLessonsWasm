using MediatR;

namespace EnglishLessonsWasm.Lessons.Delete;

public sealed class DeleteLessonCommand : IRequest
{
    public Guid Id { get; set; }
}

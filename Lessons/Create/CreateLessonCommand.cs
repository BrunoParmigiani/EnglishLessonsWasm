using EnglishLessonsWasm.Lessons.DTO;
using MediatR;

namespace EnglishLessonsWasm.Lessons.Create;

public sealed class CreateLessonCommand : IRequest<LessonDTO>
{
    public int Number { get; set; }
}

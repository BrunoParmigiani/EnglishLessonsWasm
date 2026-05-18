using EnglishLessonsWasm.Lessons.DTO;
using MediatR;

namespace EnglishLessonsWasm.Lessons.GetById;

public sealed class GetLessonByIdQuery : IRequest<LessonDTO>
{
    public Guid Id { get; set; }
}

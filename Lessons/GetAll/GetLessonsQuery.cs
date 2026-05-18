using EnglishLessonsWasm.Lessons.DTO;
using MediatR;

namespace EnglishLessonsWasm.Lessons.GetAll;

public sealed class GetLessonsQuery : IRequest<List<LessonDTO>>
{
}

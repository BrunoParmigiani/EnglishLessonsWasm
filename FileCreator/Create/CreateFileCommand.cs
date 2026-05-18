using EnglishLessonsWasm.FileCreator.Strategies;
using EnglishLessonsWasm.Lessons.DTO;
using MediatR;

namespace EnglishLessonsWasm.FileCreator.Create;

public sealed class CreateFileCommand : IRequest<LessonFile>
{
    public LessonDTO Lesson { get; set; }
    public IFileCreatorStrategy Strategy { get; set; }
}

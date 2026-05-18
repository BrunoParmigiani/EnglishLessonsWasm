using EnglishLessonsWasm.Lessons.Models;

namespace EnglishLessonsWasm.FileCreator.Strategies;

public interface IFileCreatorStrategy
{
    public LessonFile CreateFile(LessonEntity lesson);
}

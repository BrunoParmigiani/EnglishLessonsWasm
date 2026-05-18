using EnglishLessonsWasm.FileCreator.Strategies;
using EnglishLessonsWasm.Lessons.Models;

namespace EnglishLessonsWasm.FileCreator;

public sealed class FileCreatorContext
{
    public IFileCreatorStrategy Strategy { get; private set; }

    public LessonFile Execute(LessonEntity lesson)
    {
        if (Strategy is null)
            throw new ArgumentNullException("Strategy cannot be null");

        return Strategy.CreateFile(lesson);
    }

    public void SetStrategy(IFileCreatorStrategy strategy)
    {
        Strategy = strategy;
    }
}

using EnglishLessonsWasm.Lessons.Models;

namespace EnglishLessonsWasm.Lessons;

public sealed class LessonsData : ILessonsData
{
    private readonly List<LessonEntity> _lessons = [];

    public LessonEntity Create(LessonEntity lesson)
    {
        _lessons.Add(lesson);
        return lesson;
    }

    public void Delete(Guid id)
    {
        var lesson = _lessons.FirstOrDefault(lesson => lesson.Id == id);

        if (lesson is null)
            return;

        _lessons.Remove(lesson);
    }

    public List<LessonEntity> GetAll()
    {
        var result = _lessons.ToList();

        return result;
    }

    public LessonEntity? GetById(Guid id)
    {
        var result = _lessons.FirstOrDefault(lesson => lesson.Id == id);

        if (result is null)
            return null;

        var lesson = new LessonEntity(result.Id, result.Number, result.Verbs, result.Words, result.Expressions);

        return lesson;
    }

    public LessonEntity Update(LessonEntity lesson)
    {
        Delete(lesson.Id);

        _lessons.Add(lesson);

        return lesson;
    }
}

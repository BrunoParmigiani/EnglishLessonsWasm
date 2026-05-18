using EnglishLessonsWasm.Lessons.Models;

namespace EnglishLessonsWasm.Lessons;

public interface ILessonsData
{
    public LessonEntity Create(LessonEntity lesson);
    public void Delete(Guid id);
    public List<LessonEntity> GetAll();
    public LessonEntity? GetById(Guid id);
    public LessonEntity Update(LessonEntity lesson);
}

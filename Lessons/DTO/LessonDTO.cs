namespace EnglishLessonsWasm.Lessons.DTO;
public sealed class LessonDTO
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public List<WordDTO> Verbs { get; set; } = [];
    public List<WordDTO> Words { get; set; } = [];
    public List<WordDTO> Expressions { get; set; } = [];
}

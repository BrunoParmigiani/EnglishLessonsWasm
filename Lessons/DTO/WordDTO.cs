namespace EnglishLessonsWasm.Lessons.DTO;
public sealed class WordDTO
{
    public string Name { get; set; }
    public string? Meaning { get; set; } = default;
    public string? Example { get; set; } = default;
}

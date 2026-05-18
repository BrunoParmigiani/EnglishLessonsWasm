namespace EnglishLessonsWasm.Lessons.Models;

public sealed class Word
{
    public string Name { get; set; }
    public string? Meaning { get; set; } = default;
    public string? Example { get; set; } = default;

    public Word(string name, string? meaning, string? example)
    {
        Validate(name);

        Name = name;
        Meaning = meaning;
        Example = example;
    }

    private void Validate(string name)
    {
        if (name is null)
            throw new InvalidOperationException("Name cannot be null");
    }
}
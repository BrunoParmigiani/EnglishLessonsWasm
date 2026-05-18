namespace EnglishLessonsWasm.Lessons.Models;

public sealed class LessonEntity
{
    public Guid Id { get; private set; }
    public int Number { get; private set; }
    public List<Word> Verbs { get; private set; } = [];
    public List<Word> Words { get; private set; } = [];
    public List<Word> Expressions { get; private set; } = [];

    public LessonEntity(Guid id, int number, List<Word> verbs, List<Word> words, List<Word> expressions)
    {
        Validate(id, number, verbs, words, expressions);

        Id = id;
        Number = number;
        Verbs = verbs;
        Words = words;
        Expressions = expressions;
    }

    private void Validate(Guid id, int number, List<Word> verbs, List<Word> words, List<Word> expressions)
    {
        if (id == Guid.Empty)
            throw new InvalidOperationException($"Id cannot be {Guid.Empty}");

        if (number < 1)
            throw new InvalidOperationException($"Number cannot be lower than 1");

        if (verbs is null)
            throw new InvalidOperationException("Verbs cannot be null");

        if (words is null)
            throw new InvalidOperationException("Words cannot be null");

        if (expressions is null)
            throw new InvalidOperationException("Expressions cannot be null");
    }
}
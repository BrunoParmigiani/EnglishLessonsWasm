using EnglishLessonsWasm.Lessons.DTO;
using MediatR;

namespace EnglishLessonsWasm.Lessons.Update;

public sealed class UpdateLessonCommand : IRequest<LessonDTO>
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public List<WordDTO> Verbs { get; set; } = [];
    public List<WordDTO> Words { get; set; } = [];
    public List<WordDTO> Expressions { get; set; } = [];
}

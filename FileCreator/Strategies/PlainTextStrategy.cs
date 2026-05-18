using EnglishLessonsWasm.Lessons.Models;
using System.Text;

namespace EnglishLessonsWasm.FileCreator.Strategies;

public sealed class PlainTextStrategy : IFileCreatorStrategy
{
    public LessonFile CreateFile(LessonEntity lesson)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lesson {lesson.Number}");
        sb.AppendLine();

        sb.AppendLine("#### Verbs ####");
        foreach (var verb in lesson.Verbs)
        {
            sb.AppendLine($"- To {verb.Name.ToLower()}: {verb.Meaning}. E.g.: {verb.Example}");
        }
        sb.AppendLine();
        
        sb.AppendLine("#### Words ####");
        foreach (var word in lesson.Words)
        {
            sb.AppendLine($"- {word.Name.ToLower()}: {word.Meaning}. E.g.: {word.Example}");
        }
        sb.AppendLine();

        sb.AppendLine("#### Useful Phrases ####");
        foreach (var expression in lesson.Expressions)
        {
            sb.AppendLine($"- {expression.Name}: {expression.Meaning}. E.g.: {expression.Example}");
        }

        string content = sb.ToString();

        var lessonFile = new LessonFile
        {
            FileFormat = FileFormats.PlainText,
            FileData = new UTF8Encoding(true).GetBytes(content)
        };

        return lessonFile;
    }
}

using EnglishLessonsWasm.Lessons.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EnglishLessonsWasm.FileCreator.Strategies;

public sealed class PDFStrategy : IFileCreatorStrategy
{
    public LessonFile CreateFile(LessonEntity lesson)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var pdf = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));
                page.DefaultTextStyle(x => x.FontFamily(Fonts.Arial));

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Item()
                            .Text($"Lesson {lesson.Number}")
                            .Bold()
                            .FontSize(24).FontColor(Colors.Black);

                        x.Spacing(20);

                        x.Item().Text("Verbs").SemiBold().FontSize(20);
                        foreach (var verb in lesson.Verbs)
                        {
                            x.Item().Text(text =>
                            {
                                text.Span($"To {verb.Name.ToLower()}: ").Bold();
                                text.Span($"{verb.Meaning}.");
                            });
                            if (verb.Example is not null)
                            {
                                x.Item().Text(text =>
                                {
                                    text.Span("E.g.: ").Bold();
                                    text.Span($"{verb.Example}.");
                                });
                            }
                            x.Spacing(10);
                        }
                        x.Spacing(20);

                        x.Item().Text("Words").SemiBold().FontSize(20);
                        foreach (var word in lesson.Words)
                        {
                            x.Item().Text(text =>
                            {
                                text.Span($"{word.Name}: ").Bold();
                                text.Span($"{word.Meaning}.");
                            });
                            if (word.Example is not null)
                            {
                                x.Item().Text(text =>
                                {
                                    text.Span("E.g.: ").Bold();
                                    text.Span($"{word.Example}.");
                                });
                            }
                            x.Spacing(10);
                        }
                        x.Spacing(20);

                        x.Item().Text("Useful Phrases").SemiBold().FontSize(20);
                        foreach (var expression in lesson.Expressions)
                        {
                            x.Item().Text(text =>
                            {
                                text.Span($"{expression.Name}: ").Bold();
                                text.Span($"{expression.Meaning}.");
                            });
                            if (expression.Example is not null)
                            {
                                x.Item().Text(text =>
                                {
                                    text.Span("E.g.: ").Bold();
                                    text.Span($"{expression.Example}.");
                                });
                            }
                            x.Spacing(10);
                        }
                    });
            });
        })
        .GeneratePdf();

        var lessonFile = new LessonFile
        {
            FileFormat = FileFormats.PDF,
            FileData = pdf
        };

        return lessonFile;
    }
}

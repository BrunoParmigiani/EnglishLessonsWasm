using AutoMapper;
using EnglishLessonsWasm.Lessons.Models;
using FluentValidation;
using MediatR;

namespace EnglishLessonsWasm.FileCreator.Create;

public sealed class CreateFileHandler : IRequestHandler<CreateFileCommand, LessonFile>
{
    private readonly IMapper _mapper;
    private readonly CreateFileCommandValidator _validator;

    public CreateFileHandler(IMapper mapper, CreateFileCommandValidator validator)
    {
        _mapper = mapper;
        _validator = validator;
    }

    public Task<LessonFile> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        FileCreatorContext context = new FileCreatorContext();
        context.SetStrategy(request.Strategy);

        var lessonEntity = _mapper.Map<LessonEntity>(request.Lesson);

        var lessonFile = context.Execute(lessonEntity);

        return Task.FromResult(lessonFile);
    }
}

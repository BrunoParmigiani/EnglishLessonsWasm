using AutoMapper;
using EnglishLessonsWasm.Lessons.DTO;
using EnglishLessonsWasm.Lessons.Models;
using FluentValidation;
using MediatR;

namespace EnglishLessonsWasm.Lessons.Create;

public sealed class CreateLessonHandler : IRequestHandler<CreateLessonCommand, LessonDTO>
{
    private readonly ILessonsData _data;
    private readonly IMapper _mapper;
    private readonly CreateLessonCommandValidator _validator;

    public CreateLessonHandler(ILessonsData data, IMapper mapper, CreateLessonCommandValidator validator)
    {
        _data = data;
        _mapper = mapper;
        _validator = validator;
    }

    public Task<LessonDTO> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);
        
        var lesson = new LessonEntity(
            Guid.NewGuid(),
            request.Number,
            new List<Word>(),
            new List<Word>(),
            new List<Word>()
            );

        var result = _data.Create(lesson);

        return Task.FromResult(_mapper.Map<LessonDTO>(result));
    }
}

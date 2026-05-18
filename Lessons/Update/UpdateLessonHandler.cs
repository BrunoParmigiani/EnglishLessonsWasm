using AutoMapper;
using EnglishLessonsWasm.Lessons.DTO;
using EnglishLessonsWasm.Lessons.Models;
using FluentValidation;
using MediatR;

namespace EnglishLessonsWasm.Lessons.Update;

public sealed class UpdateLessonHandler : IRequestHandler<UpdateLessonCommand, LessonDTO>
{
    private readonly ILessonsData _data;
    private readonly IMapper _mapper;
    private readonly UpdateLessonCommandValidator _validator;

    public UpdateLessonHandler(ILessonsData data, IMapper mapper, UpdateLessonCommandValidator validator)
    {
        _data = data;
        _mapper = mapper;
        _validator = validator;
    }

    public Task<LessonDTO> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        var lesson = new LessonEntity(
                request.Id,
                request.Number,
                request.Verbs.Select(_mapper.Map<Word>).ToList(),
                request.Words.Select(_mapper.Map<Word>).ToList(),
                request.Expressions.Select(_mapper.Map<Word>).ToList()
            );

        var result =  _data.Update(lesson);

        return Task.FromResult(_mapper.Map<LessonDTO>(result));
    }
}

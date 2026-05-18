using AutoMapper;
using EnglishLessonsWasm.Lessons.DTO;
using FluentValidation;
using MediatR;

namespace EnglishLessonsWasm.Lessons.GetById;

public sealed class GetLessonByIdHandler : IRequestHandler<GetLessonByIdQuery, LessonDTO>
{
    private readonly ILessonsData _data;
    private readonly IMapper _mapper;
    private readonly GetLessonByIdQueryValidator _validator;

    public GetLessonByIdHandler(ILessonsData data, IMapper mapper, GetLessonByIdQueryValidator validator)
    {
        _data = data;
        _mapper = mapper;
        _validator = validator;
    }

    public Task<LessonDTO> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        var result = _data.GetById(request.Id);

        return Task.FromResult(_mapper.Map<LessonDTO>(result));
    }
}

using AutoMapper;
using EnglishLessonsWasm.Lessons.DTO;
using MediatR;

namespace EnglishLessonsWasm.Lessons.GetAll;

public sealed class GetLessonsHandler : IRequestHandler<GetLessonsQuery, List<LessonDTO>>
{
    private readonly ILessonsData _data;
    private readonly IMapper _mapper;

    public GetLessonsHandler(ILessonsData data, IMapper mapper)
    {
        _data = data;
        _mapper = mapper;
    }

    public Task<List<LessonDTO>> Handle(GetLessonsQuery request, CancellationToken cancellationToken)
    {
        var result =  _data.GetAll();

        return Task.FromResult(result.Select(_mapper.Map<LessonDTO>).ToList());
    }
}

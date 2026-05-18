using AutoMapper;
using EnglishLessonsWasm.Lessons.DTO;
using EnglishLessonsWasm.Lessons.Models;

namespace EnglishLessonsWasm.Lessons.Mappings;

public sealed class ModelToDTOMapProfile : Profile
{
    public ModelToDTOMapProfile()
    {
        CreateMap<LessonEntity, LessonDTO>().ReverseMap();
        CreateMap<Word, WordDTO>().ReverseMap();
    }
}

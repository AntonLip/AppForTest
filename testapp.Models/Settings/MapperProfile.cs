using AutoMapper;
using testapp.Models.DtoModels.Question;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.DtoModels.Answer;

namespace testapp.Models.Settings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, AppUserDto>()
                .ForMember(dest => dest.GroupNumber,
                    opt =>
                    {
                        opt.MapFrom<UserGroupNumberResolver>();
                    });
            CreateMap<Question, GetQuestionDto>()
                .ForMember(dest => dest.Discipline,
                    opt =>
                    {
                        opt.MapFrom<DisciplineNameResolver>();
                    })
                .ForMember(dest => dest.Answers,
                    opt => opt.MapFrom(src => src.Answers))
                .ForMember(dest => dest.ThemeName,
                    opt =>
                    {
                        opt.MapFrom<ThemeNameResolver>();
                    });
            CreateMap<QuestionDto, Question>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ThemeId, opt => opt.MapFrom(src => src.Discipline.Themes[0].Id))
                //.ForMember(dest => dest.Theme, opt => opt.MapFrom(src => src.Discipline.Themes[0]))
                //.ForMember(dest => dest.Answers, opt => opt.Ignore());
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));

            CreateMap<AnswerDto, Answer>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrect))
                .ForMember(dest => dest.QuestionId, opt => opt.Ignore())
                .ForMember(dest => dest.Question, opt => opt.Ignore());
            CreateMap<Answer, AnswerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrect));

            CreateMap<Results, ResultDto>()
                .ForMember(dest => dest.User,
                opt =>
                {
                    opt.MapFrom<UserResolver>();
                })
                .ForMember(dest => dest.DisciplineName,
                    opt =>
                    {
                        opt.MapFrom<DisciplineNameResolver>();
                    })
                .ForMember(dest => dest.ThemeNames,
                    opt =>
                    {
                        opt.MapFrom<ThemeNameResolver>();
                    });
            
            
            // CreateMap<QuestionDto, Question>()
            //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //     .ForMember(dest => dest.DisciplinesId, opt => opt.MapFrom(src => src.DisciplinesId));
            // CreateMap<Question, QuestionDto>()
            //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //     .ForMember(dest => dest.DisciplinesId, opt => opt.MapFrom(src => src.DisciplinesId));
        }
    }
}

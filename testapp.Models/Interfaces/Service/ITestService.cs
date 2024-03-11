using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.DtoModels.Question;

namespace testapp.Models.Interfaces.Service
{
    public interface ITestService : IService<Question, GetQuestionDto, QuestionDto, GetQuestionDto, Guid>
    {
        Task<GetQuestionDto> AddFullQuestionAsync(QuestionDto model);
        Task<ResultDto> CheckTest(List<GetQuestionDto> model, ApplicationUser user);
        GetQuestionDto GetQuestionWithAnswersById(Guid id);
        List<GetQuestionDto> GetTestByDisciplineId(Guid id);
        List<GetQuestionDto> GetTestByThemeId(Guid id);
        List<GetQuestionDto> GetTestByThemes(List<ThemeDto> models);
    }
}

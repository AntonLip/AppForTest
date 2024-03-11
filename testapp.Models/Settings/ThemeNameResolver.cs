using AutoMapper;
using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.DtoModels.Question;
using testapp.Models.Interfaces.Service;

namespace testapp.Models.Settings
{
    internal class ThemeNameResolver : IValueResolver<Question, GetQuestionDto, string>, IValueResolver<Results, ResultDto, List<string>>
    {
        private readonly IDisciplineService _service;
        private readonly IResultThemeRepository _resultThemeRepository;
        private readonly IThemeRepository _themeRepository;
        public ThemeNameResolver(IDisciplineService service, IResultThemeRepository resultThemeRepository, IThemeRepository themeRepository)
        {
            _service = service;
            _themeRepository = themeRepository;
            _resultThemeRepository = resultThemeRepository;
        }
        public string Resolve(Question source, GetQuestionDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                var theme = _themeRepository.GetByIdAsync(source.ThemeId).Result;
                return theme.Name;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public List<string> Resolve(Results source, ResultDto destination, List<string> destMember, ResolutionContext context)
        {
            try
            {
                var resultThemes = _resultThemeRepository.GetWithInclude(p => p.ResultId == source.Id).ToList();
                List<string> themeName = new List<string>();
                foreach (var resultTheme in resultThemes)
                {
                    var theme = _themeRepository.GetByIdAsync(resultTheme.ThemeId).Result;
                    themeName.Add(theme.Name);
                }
                return themeName;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return new List<string>();
            }
        }
    }
}

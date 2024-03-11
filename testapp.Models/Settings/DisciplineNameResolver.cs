using AutoMapper;
using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.DtoModels.Question;
using testapp.Models.Interfaces.Service;

namespace testapp.Models.Settings
{
    internal class DisciplineNameResolver : IValueResolver<Question, GetQuestionDto, string>, IValueResolver<Question, GetQuestionDto, Disciplines>,
        IValueResolver<Results, ResultDto, string>
    {
        private readonly IDisciplineService _service;
        public DisciplineNameResolver(IDisciplineService service)
        {
            _service = service;
        }
        public string Resolve(Question source, GetQuestionDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                var discipline = _service.GetDiscpilineByThemeId(source.ThemeId).Result;
                return discipline.Name;
            }
            catch (Exception ex )
            {
                Console.Error.WriteLine(ex.Message);
                return "";
            }
        }

        public Disciplines Resolve(Question source, GetQuestionDto destination, Disciplines destMember, ResolutionContext context)
        {
            try
            {
                var discipline = _service.GetDiscpilineByThemeId(source.ThemeId).Result;
                return discipline;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return new Disciplines();
            }
        }

        public string Resolve(Results source, ResultDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                var discipline = _service.GetByIdAsync(source.DisciplineId).Result;
                return discipline.Name;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return String.Empty;
            }
        }
    }
}

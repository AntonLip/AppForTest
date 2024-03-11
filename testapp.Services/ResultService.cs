using AutoMapper;
using testapp.Models.Interfaces.Repository;
using testapp.Models.Interfaces.Service;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;

namespace testapp.Services
{
    public class ResultService : BaseService<Results, ResultDto, Results, Results>, IResultService
    {
        private readonly IResultThemeRepository _resultThemeRepository;
        public ResultService(IResultRepository repository, IMapper mapper, IResultThemeRepository resultThemeRepository)
            : base(repository, mapper)
        {
            _resultThemeRepository = resultThemeRepository;
        }

        public List<ResultDto> GetbyUserId(string? userid)
        {
            var results = _repository.GetWithInclude(p => p.UserId == userid).ToList();
            return results is null ? throw new ArgumentNullException(nameof(results)) : _mapper.Map<List<ResultDto>>(results);
        }
        
        public override 
    }
}

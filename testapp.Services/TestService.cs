using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.DtoModels.Question;
using testapp.Models.Interfaces.Repository;
using testapp.Models.Interfaces.Service;

namespace testapp.Services
{
    public class TestService : BaseService<Question, GetQuestionDto, QuestionDto, GetQuestionDto>, ITestService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IDisciplineService _disciplineService;
        private readonly IQuestionRepository _questionRepository;
        private readonly IResultService _resultService;
        private readonly IResultThemeRepository _resultThemeRepository;
        public TestService(IQuestionRepository repository, IMapper mapper, IResultThemeRepository resultThemeRepository,
                           IAnswerRepository answerRepository, IDisciplineService disciplineService, IResultService resultService,
                           IQuestionRepository questionRepository)
        : base(repository, mapper)
        {
            _answerRepository = answerRepository;
            _disciplineService = disciplineService;
            _questionRepository = questionRepository;
            _resultService = resultService;
            _resultThemeRepository = resultThemeRepository;
        }

        public async Task<GetQuestionDto> AddFullQuestionAsync(QuestionDto model)
        {

            if (model is null)
                throw new ArgumentNullException(nameof(model));
            var id = Guid.NewGuid();
            await _repository.AddAsync(new Question { Title = model.Title, ThemeId = model.Discipline.Themes[0].Id, Id = id });
            foreach (var item in model.Answers)
            {
                await _answerRepository.AddAsync(new Answer { IsCorrect = item.IsCorrect, QuestionId = id, Title = item.Name });
            }
            var res = await _repository.GetByIdAsync(id);
            return res is null ? throw new ArgumentNullException(nameof(res)) : _mapper.Map<GetQuestionDto>(res);

        }
        public override async Task<GetQuestionDto> AddAsync(QuestionDto modelDto, CancellationToken cancellationToken = default)
        {
            var newQuestion = await base.AddAsync(modelDto, cancellationToken);
            return newQuestion is null ? throw new ArgumentNullException(nameof(newQuestion)) : newQuestion;
        }
        public GetQuestionDto GetQuestionWithAnswersById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var question = _repository.GetWithInclude(p => p.Id == id, p => p.Answers).FirstOrDefault();
            return question is null ? throw new ArgumentNullException(nameof(question)) : _mapper.Map<GetQuestionDto>(question);
        }
        public override async Task<GetQuestionDto> UpdateAsync(Guid id, GetQuestionDto modelDto, CancellationToken cancellationToken = default)
        {
            if (id != modelDto.Id)
                throw new ArgumentNullException();
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            if (modelDto is null)
                throw new ArgumentNullException(nameof(modelDto));
            var question = _repository.GetWithInclude(p => p.Id == id, p => p.Answers).FirstOrDefault();
            question.Title = modelDto.Title;
            question.ThemeId = modelDto.Discipline.Themes[0].Id;
            foreach (var item in modelDto.Answers)
            {
                if (item.Id != Guid.Empty)
                {
                    var theme = await _answerRepository.GetByIdAsync(item.Id, cancellationToken);

                    if (item.IsDelete)
                        await _answerRepository.RemoveAsync(theme);
                    if (theme.Title != item.Name)
                    {
                        theme.Title = item.Name;
                        await _answerRepository.UpdateAsync(theme);
                    }
                }
                else
                {
                    await _answerRepository.AddAsync(new Answer { Id = Guid.NewGuid(), IsCorrect = item.IsCorrect, QuestionId = question.Id, Title = item.Name });
                }
            }

            return question is null ? throw new ArgumentNullException(nameof(question)) : _mapper.Map<GetQuestionDto>(question);

        }
        public override async Task<GetQuestionDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var question = _repository.GetWithInclude(p => p.Id == id, p => p.Answers).FirstOrDefault();
            foreach (var item in question.Answers)
            {
                await _answerRepository.RemoveAsync(item, cancellationToken);
            }
            return await base.RemoveAsync(id, cancellationToken);
        }
        public List<GetQuestionDto> GetTestByDisciplineId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            List<Question> questions = new List<Question>();
            var discipline = _disciplineService.GetByIdWithTheme(id);
            if (discipline is null)
                throw new ArgumentNullException(nameof(discipline));
            foreach (var item in discipline.Themes)
            {
                questions.AddRange(_repository.GetWithInclude(p => p.ThemeId == item.Id, p => p.Answers).ToList());
            }
            if (questions.Count == 0)
                throw new ArgumentException("questions by choosen disciplines don't find");
            return _mapper.Map<List<GetQuestionDto>>(questions);
        }
        public List<GetQuestionDto> GetTestByThemeId([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            List<Question> questions = _repository.GetWithInclude(p => p.ThemeId == id, p => p.Answers).ToList();

            return questions is null ? throw new ArgumentException("questions by choosen disciplines don't find") : _mapper.Map<List<GetQuestionDto>>(questions);
        }
        public List<GetQuestionDto> GetTestByThemes(List<ThemeDto> models)
        {
            if (models is null)
                throw new ArgumentNullException(nameof(models));
            List<Question> questions = new List<Question>();
            foreach (var item in models)
            {
                questions.AddRange(_repository.GetWithInclude(p => p.ThemeId == item.Id, p => p.Answers).ToList());
            }
            return questions.Count == 0 ? throw new ArgumentException("questions by choosen disciplines don't find") : _mapper.Map<List<GetQuestionDto>>(questions);
        }
        public async Task<ResultDto> CheckTest(List<GetQuestionDto> model, ApplicationUser user)
        {            
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            double currMark = 0.0;
            foreach (var questionDto in model)
            {
                var question = _repository.GetWithInclude(p => p.Id == questionDto.Id, p => p.Answers).FirstOrDefault();
                int countCorrectAnswerByUser = 0;
                int countCorrectAnswer = question.Answers.Where(p => p.IsCorrect == true).Count();
                int countWrongAnswer = 0;
                foreach (var answerDto in questionDto.Answers)
                {
                    var ans = question.Answers.Find(p => p.Id == answerDto.Id);
                    if (answerDto.IsChoosen == true && ans.IsCorrect == true)
                    {
                        countCorrectAnswerByUser++;
                    }
                    if(answerDto.IsChoosen == true && ans.IsCorrect == false)
                        countWrongAnswer++;
                }
                if(countCorrectAnswerByUser == countCorrectAnswer && countWrongAnswer == 0)
                    currMark += 1;
            }
            int mark = (int)((currMark / (double)model.Count) * 10);
            Results result = new Results
            {
                DateToTakePass = DateTime.Now,
                Grade = mark,
                UserId = user.Id,
                DisciplineId = model[0].Discipline.Id
            };
            var resultDto = await _resultService.AddAsync(result);
            if (resultDto is not null)
            {
                List<string> themeNames = new List<string>();
                foreach (var question in model)
                {
                    if (!themeNames.Contains(question.ThemeName))
                    {
                        themeNames.Add(question.ThemeName);
                        var theme = _disciplineService.GetThemeByName(question.ThemeName);
                        ResultTheme resultTheme = new ResultTheme
                        {
                            ThemeId = theme.Id,
                            ResultId = resultDto.Id
                        };
                        await _resultThemeRepository.AddAsync(resultTheme);
                    }
                }
                return resultDto;
            }
            else
            {
                return null;
            }
        }
    }
}

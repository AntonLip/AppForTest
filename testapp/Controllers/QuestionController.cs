using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testapp.Models.DtoModels.Question;
using testapp.Models.Interfaces.Service;

namespace testapp.Controllers
{
    [Authorize(Roles = "Admin, Преподаватель")]


    public class QuestionController : Controller
    {
        private readonly ITestService _service;
        private readonly IDisciplineService _disciplineService;
        public QuestionController(ITestService service, IDisciplineService disciplineService)
        {
            _service = service;
            _disciplineService = disciplineService;
        }
        public async Task<IActionResult> Index()
        {
            int count = _service.GetCountEntity();
            var question = await _service.GetAllAsync(0, count);
            return View(question);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAsync(Guid id)
        {
            try
            {
                QuestionDto model = new QuestionDto();
                model.Answers = new List<Models.DtoModels.Answer.AnswerDto>();
                model.Discipline = await _disciplineService.GetDiscpilineByThemeId(id);
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(QuestionDto model)
        {
            try
            {
                var question = await _service.AddFullQuestionAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var model = _service.GetQuestionWithAnswersById(id);
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GetQuestionDto model)
        {

            var updatedQuestion = await _service.UpdateAsync(model.Id, model);
            if (updatedQuestion != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            GetQuestionDto model = _service.GetQuestionWithAnswersById(id);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var model = await _service.RemoveAsync(id);
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.DtoModels.Question;
using testapp.Models.Interfaces.Service;
using testapp.ViewModels;

namespace testapp.Controllers
{
    public class TestController : Controller
    {
        private readonly IDisciplineService _disciplineService;
        private readonly ITestService _testService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestController(ITestService testService, IDisciplineService disciplineService, 
                              UserManager<ApplicationUser> userManager)
        {
            _testService = testService;
            _disciplineService = disciplineService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IndexTestViewModel model = new IndexTestViewModel();
            model.Disciplines = _disciplineService.GetAllWithTheme();
            int cnt = _disciplineService.GetCountEntity();
            List<Disciplines> disciplines = (List<Disciplines>)await _disciplineService.GetAllAsync(0, cnt);
            ViewBag.Disciplines = new SelectList(disciplines, "Id", "Name");
            return View(model);
        }
       [HttpGet]
        public IActionResult GetTestByDisciplineId(Guid DisciplineId) 
        {
            try
            {
                List<GetQuestionDto> model = _testService.GetTestByDisciplineId(DisciplineId);
                return View("Test", model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult GetTestByThemeId(Guid ThemeId)
        {
            try
            {
                List<GetQuestionDto> model = _testService.GetTestByThemeId(ThemeId);
                return View("Test", model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult GetTestByThemes([FromBody] List<ThemeDto> themes)
        {
            try
            {
                List<GetQuestionDto> model = _testService.GetTestByThemes(themes);
                return View("Test", model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CheckTest(List<GetQuestionDto> model)
        {
            if (model is null)
                return BadRequest();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            ResultDto result = await _testService.CheckTest(model, user);
            return RedirectToAction("Index", "Result");
        }

    }
}

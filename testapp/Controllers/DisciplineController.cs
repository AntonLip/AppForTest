using Microsoft.AspNetCore.Mvc;
using testapp.Models.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using testapp.ViewModels;
using testapp.Models.ViewModels;

namespace testapp.Controllers
{
    [Authorize(Roles = "Admin, Преподаватель")]

    public class DisciplineController : Controller
    {
        private readonly IDisciplineService _service;
        public DisciplineController(IDisciplineService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var cnt = _service.GetCountEntity();
                var desciplines = await _service.GetAllAsync(0, cnt);
                if (desciplines is null)
                    return NotFound();
                return View(desciplines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            AddDisciplineViewModel model = new AddDisciplineViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddDisciplineViewModel model)
        {
            try
            {
                if (model is null)
                    return BadRequest();
                var res = await _service.AddAsync(model.Discipline);

                foreach (var item in model.Themes)
                {
                    item.DisciplinesId = res.Id;
                    await _service.AddThemeToDisciplinesAsync(item);
                }

                if (res is null)
                    return View("Error");
                return Redirect("Index");
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
            EditDisciplines model = _service.GetForEditById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditDisciplines model)
        {
            await _service.UpdateWithThemeAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var model = _service.GetByIdWithTheme(id);
            return View(model);
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return NotFound();
                var desciplines = await _service.RemoveAsync(id);
                if (desciplines is null)
                    return View("Error");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
        }
        [AllowAnonymous]
        [HttpGet]

        public IActionResult GetThemesByDisciplineId(Guid id)
        {
            var model = _service.GetByIdWithTheme(id);
            return Json(model.Themes);
        }
    }
}

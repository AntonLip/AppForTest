using Microsoft.AspNetCore.Mvc;
using testapp.Models.Interfaces.Service;
using testapp.Models.DbModels;
using Microsoft.AspNetCore.Authorization;

namespace testapp.Controllers
{
    [Authorize(Roles = "Admin")]

    public class GroupController : Controller
    {
        private readonly IGroupService _service;
        public GroupController(IGroupService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            int cnt = _service.GetCountEntity();
            var groups = await _service.GetAllAsync(0, cnt);
            return View(groups);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Group  model)
        {
            try
            {               
                var res = await _service.AddAsync(model);
                if(res is null)
                    return View("Error");
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return NotFound();
                var group = await _service.RemoveAsync(id);
                if(group is null)
                    return View("Error");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return View("Error");
                }
                else
                {
                    var groups = await _service.GetByIdAsync(id);
                    return View(groups);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Group model)
        {
            try
            {
                if (model is null)
                {
                    return View("Error");
                }
                else
                {
                    await _service.AddAsync(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

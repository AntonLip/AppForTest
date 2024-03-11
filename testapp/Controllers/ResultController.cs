using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.Interfaces.Service;
using testapp.Services;

namespace testapp.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultService _resultService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGroupService _groupService;

        public ResultController(IResultService resultService, UserManager<ApplicationUser> userManager, IGroupService groupService)
        {
            _resultService = resultService;
            _userManager = userManager;
            _groupService = groupService;

        }
        public async Task<IActionResult> Index()
        {
            List<ResultDto> models = new List<ResultDto>();
            int count = _groupService.GetCountEntity(); 
            var groups = await _groupService.GetAllAsync(0, count);
            ViewBag.Groups = groups;
            if (User.IsInRole("Admin") || User.IsInRole("Преподаватель"))
            {
                int countEntities = _resultService.GetCountEntity();
                models = (List<ResultDto>)await _resultService.GetAllAsync(0, countEntities);
                   
            }
            else
            {
                var userid = _userManager.GetUserId(User);
                models = _resultService.GetbyUserId(userid);
            }
            return View(models);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _resultService.GetByIdAsync(id);
            return View(model);
        }
        public async Task<IActionResult> FindByGroupIdAsync(Guid id)
        {
            var users = _userManager.Users.ToList().Where(p => p.GroupId == id);
            List<ResultDto> models = new List<ResultDto>();
            foreach (var user in users)
            {
                var resultDto = _resultService.GetbyUserId(user.Id);
                models.AddRange(resultDto);
            }
            int count = _groupService.GetCountEntity();
            var groups = await _groupService.GetAllAsync(0, count);
            ViewBag.Groups = groups;
            return View("Index", models);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return View("Error");
                await _resultService.RemoveAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }
    }
}

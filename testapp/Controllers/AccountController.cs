using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using testapp.Models.Interfaces.Service;
using testapp.Models.DbModels;
using testapp.ViewModels.AccountViewModels;

namespace Test.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IGroupService _groupService;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                 IGroupService groupService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _groupService = groupService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync()
        {
            int cnt = _groupService.GetCountEntity();
            var groups = await _groupService.GetAllAsync(0, cnt);
            ViewBag.Groups  = new SelectList(groups.Except(groups.Where(p => p.Name == "Admin" && p.Name == "Преподаватели")), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViweModel registerViweModel)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = registerViweModel.Email,
                    Email = registerViweModel.Email,
                    FirstName = registerViweModel.FirstName,
                    LastName = registerViweModel.LastName,
                    GroupId = registerViweModel.GroupId,
                };
                var result = _userManager.CreateAsync(user, registerViweModel.Password);
                if (result.Result.Succeeded)
                {
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var er in result.Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, er.Description);
                }
                return View(registerViweModel);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return View("Error");
            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogginViewModel loginViewModel, string returnUrl)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Log In Attempt");
                    return View(loginViewModel);
                }

                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Log In Attempt");
                }

                return View(loginViewModel);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return View("Error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> EmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already use");
            }
        }



    }
}

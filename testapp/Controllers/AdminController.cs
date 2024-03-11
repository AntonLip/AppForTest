using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;
using testapp.Models.Interfaces.Service;
using testapp.ViewModels.AdminViewModels;

namespace Test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private  readonly IGroupService _groupService;
        private readonly IMapper _mapper; 
        public AdminController(RoleManager<IdentityRole> roleManager,
                               UserManager<ApplicationUser> userManager,
                               IGroupService groupService,
                               IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _groupService = groupService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var users = _userManager.Users.ToList();
            List<ApplicationUserDto> userDto = new List<ApplicationUserDto>();
            foreach (var user in users)
            {
                List<string> roles = null;
                roles = (List<string>?)await _userManager.GetRolesAsync(user);
                var group = await _groupService.GetByIdAsync(user.GroupId);
                if(roles.Count == 0)
                {
                    roles = new List<string>();
                    roles.Add("Не назначено");
                }
                userDto.Add(new ApplicationUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = roles[0],
                    Group = group.Name
                });
                
            }
            int cnt = _groupService.GetCountEntity();
            var groups = await _groupService.GetAllAsync(0, cnt);
            ViewBag.Groups = groups;
            return View(userDto);
        }    
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} not fount";
                return View("Error");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("Index");
            }
        }
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var userRole = await _userManager.GetRolesAsync(user);
            var model = new EditUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                UserName = user.UserName,
                LastName = user.LastName,
                Roles = userRole,
                Email = user.Email,
                GroupId = user.GroupId
            };
            var types = _roleManager.Roles;
            ViewBag.Types = new SelectList(types, "Id", "Name");
            int cnt = _groupService.GetCountEntity();
            var groups = await _groupService.GetAllAsync(0, cnt);
           
            ViewBag.Group = new SelectList(groups, "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
                       
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.GroupId = model.GroupId;
                var result = await _userManager.UpdateAsync(user);
                var userRoles = await _userManager.GetRolesAsync(user);
                var role = await _roleManager.FindByIdAsync(model.UserRoleId);
                foreach (var item in userRoles)
                {
                    await _userManager.RemoveFromRoleAsync(user, item);
                }
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> FindByGroupIdAsync(Guid id)
        {
            var users = _userManager.Users.ToList().Where(p => p.GroupId == id);
            List<ApplicationUserDto> userDto = new List<ApplicationUserDto>();
            foreach (var user in users)
            {
                List<string> roles = null;
                roles = (List<string>?)await _userManager.GetRolesAsync(user);
                var group = await _groupService.GetByIdAsync(user.GroupId);
                if (roles.Count == 0)
                {
                    roles = new List<string>();
                    roles.Add("Не назначено");
                }
                userDto.Add(new ApplicationUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = roles[0],
                    Group = group.Name
                });

            }
            int cnt = _groupService.GetCountEntity();
            var groups = await _groupService.GetAllAsync(0, cnt);
            ViewBag.Groups = groups;
            return View("Index", userDto);
        }
    }
}

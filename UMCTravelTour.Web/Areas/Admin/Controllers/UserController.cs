using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.CustomIdentity;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMCTravelTour.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Constant.Role.Administrator)]
    public class UserController : BaseController
    {
        private readonly UMCTravelContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        SignInManager<DreamTourUser> _signInManager;
        UserManager<DreamTourUser> _userManager;
        public UserController(UMCTravelContext context, IUnitOfWork unitOfWork, IMapper mapper, SignInManager<DreamTourUser> signInManager, UserManager<DreamTourUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(string roleName, string search)
        {
            var identityUsers = _unitOfWork.UserRepository.GetUsers();
            var dreamTourUsers = _mapper.Map<IEnumerable<DreamTourUser>>(identityUsers);

            if (!string.IsNullOrEmpty(roleName))
            {
                if (roleName == "Customer")
                {
                    ViewBag.currentRoleShow = roleName;
                    if (!string.IsNullOrEmpty(search))
                    {
                        return View(dreamTourUsers.Where(u => _userManager.GetRolesAsync(u).Result.Count() < 1 &&
                        (u.FirstName.ToLower().Contains(search.ToLower()) || u.LastName.ToLower().Contains(search.ToLower()))));
                    }
                    return View(dreamTourUsers.Where(u => _userManager.GetRolesAsync(u).Result.Count() < 1));
                }
                var identityRoles = _unitOfWork.RoleRepository.GetRoles();
                foreach (var role in identityRoles)
                {
                    if (roleName == role.Name)
                    {
                        ViewBag.currentRoleShow = roleName;
                        if (!string.IsNullOrEmpty(search))
                        {
                            return View(dreamTourUsers.Where(u => _userManager.GetRolesAsync(u).Result.Contains(roleName) &&
                            (u.FirstName.ToLower().Contains(search.ToLower()) || u.LastName.ToLower().Contains(search.ToLower()))));
                        }
                        return View(dreamTourUsers.Where(u => _userManager.GetRolesAsync(u).Result.Contains(roleName)));
                    }
                }
            }
            
            ViewBag.currentRoleShow = "All";
            if (!string.IsNullOrEmpty(search))
            {
                return View(dreamTourUsers.Where(u => u.FirstName.ToLower().Contains(search.ToLower()) || u.LastName.ToLower().Contains(search.ToLower())));
            }
            return View(dreamTourUsers);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var identityUser = _unitOfWork.UserRepository.GetUser(id);
            var dreamTourUser = _mapper.Map<DreamTourUser>(identityUser);
            var identityRoles = _unitOfWork.RoleRepository.GetRoles();
            ViewBag.Roles = identityRoles;
            // Mac dinh la chi co 1 role
            var userRoles = await _signInManager.UserManager.GetRolesAsync(dreamTourUser);

            var editModel = new EditUserModel()
            {
                User = dreamTourUser,
                Role = userRoles.FirstOrDefault()
            };

            ViewData["currentUser"] = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            return View(editModel);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserModel data)
        {
            var identityUser = _unitOfWork.UserRepository.GetUser(data.User.Id);
            var dreamTourUser = _mapper.Map<DreamTourUser>(identityUser);

            if (dreamTourUser == null)
            {
                return NotFound();
            }

            dreamTourUser.FirstName = data.User.FirstName;
            dreamTourUser.LastName = data.User.LastName;
            dreamTourUser.Email = data.User.Email;
            dreamTourUser.PhoneNumber = data.User.PhoneNumber;

            var userRoles = await _signInManager.UserManager.GetRolesAsync(dreamTourUser);
            if (userRoles.Count() > 0)
            {
                var role = userRoles.FirstOrDefault();

                // remove old role
                await _signInManager.UserManager.RemoveFromRoleAsync(dreamTourUser, role);
            }
            if (data.Role != "none")
            {
                // add new role
                await _signInManager.UserManager.AddToRoleAsync(dreamTourUser, data.Role);
            }
            var user = _mapper.Map<IdentityUser>(dreamTourUser);
            _unitOfWork.UserRepository.UpdateUser(user);
            _unitOfWork.SaveChanges();

            var currentUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (user.UserName == currentUser.UserName)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home", new { returnUrl = "/Admin", area = "" });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = Constant.Role.Administrator)]
        public IActionResult Delete(string id)
        {
            _unitOfWork.UserRepository.DeleteUser(id);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DreamTourUser dreamTourUser, string newPassword)
        {
            if (string.IsNullOrEmpty(dreamTourUser.FirstName) ||
                string.IsNullOrEmpty(dreamTourUser.LastName) ||
                string.IsNullOrEmpty(dreamTourUser.Email) ||
                string.IsNullOrEmpty(dreamTourUser.PhoneNumber) ||
                string.IsNullOrEmpty(newPassword))
            {
                TempData["msg"] = "Create failed";
                return View("Create");
            }

            var user = new DreamTourUser()
            {
                FirstName = dreamTourUser.FirstName,
                LastName = dreamTourUser.LastName,
                Email = dreamTourUser.Email,
                NormalizedEmail = dreamTourUser.Email.ToUpper(),
                UserName = dreamTourUser.FirstName + "#" + Guid.NewGuid().ToString().Substring(0, 4),
                NormalizedUserName = dreamTourUser.FirstName.ToUpper(),
                PhoneNumber = dreamTourUser.PhoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (_unitOfWork.UserRepository.GetUsers().FirstOrDefault(u => u.Email == dreamTourUser.Email) == null)
            {
                var password = new PasswordHasher<DreamTourUser>();
                var hashed = password.HashPassword(user, newPassword);
                user.PasswordHash = hashed;
                if(_unitOfWork.UserRepository.GetUsers().Any(u => u.PhoneNumber == dreamTourUser.PhoneNumber))
                {
                    TempData["msg"] = "Phone number is existed";
                    return View("Create");
                }
                var userStore = new UserStore<DreamTourUser>(_context);
                var result = await userStore.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, Constant.Role.Employee);
            }
            else
            {
                TempData["msg"] = "Email is existed";
                return View("Create");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

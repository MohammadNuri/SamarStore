using SamarStore.Application.Services.Users.Commands.RemoveUser;
using SamarStore.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SamarStore.Application.Services.Users.Commands.RegisterUsers;
using SamarStore.Application.Services.Users.Queries.GetUsers;
using SamarStore.Application.Services.Users.Commands.UserStatusChange;
using SamarStore.Application.Services.Users.Commands.EditUser;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(
            IGetUsersService getUsersService,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IUserStatusChangeService userStatusChangeService,
            IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userStatusChangeService = userStatusChangeService;
            _editUserService = editUserService;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey
            }));
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Register(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                RePassword = RePassword
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserStatusChange(long UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }
        [HttpPost]
        public IActionResult EditUser(long UserId, string Fullname, string Email)
        {
            return Json(_editUserService.Execute(new RequestEditUserDto
            {
                Fullname = Fullname,
                Email = Email,
                UserId = UserId 
            }));
        }

    }
}
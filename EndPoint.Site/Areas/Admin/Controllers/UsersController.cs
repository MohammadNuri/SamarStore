using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        public UsersController(IGetUsersService getUsersService)
        {
            _getUsersService = getUsersService; 
        }


        public IActionResult Index(string searchKey , int page = 1)
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
            return View();  
        }
    }
}

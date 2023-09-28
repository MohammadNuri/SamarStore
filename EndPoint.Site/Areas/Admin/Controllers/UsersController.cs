using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        public UsersController(IGetUsersService getUsersService)
        {
            _getUsersService = getUsersService; 
        }


        [Area("Admin")]
        public IActionResult Index(string searchKey , int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey 
            }));
        }
    }
}

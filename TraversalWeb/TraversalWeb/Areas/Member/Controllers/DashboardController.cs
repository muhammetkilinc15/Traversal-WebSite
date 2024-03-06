using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = currentUser.Name + " " + currentUser.Surname;
            ViewBag.userImage = "/wwwroot/MemberImages/" + currentUser.ImageUrl;
            return View();
        }
    }
}

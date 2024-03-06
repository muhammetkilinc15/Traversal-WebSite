using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalWeb.Areas.Member.Models;

namespace TraversalWeb.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/{controller}/{action}")]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

		[HttpGet]
        public async Task< IActionResult> Index()
		{
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel()
            {
                Name = currentUser.Name,
                Surname = currentUser.Surname,
                Mail = currentUser.Email,
                ImageUrl = currentUser.ImageUrl
            };
            return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.Image!=null)
            {
                // --------> Seçilen Dosyayı sisteme yüklemek için
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/MemberImages/" + imageName;
                var stream = new FileStream(saveLocation,FileMode.Create);            
                await p.Image.CopyToAsync(stream);
                p.ImageUrl = imageName;
                // <-------- Seçilen dosyayı sisteme kaydediyor


                currentUser.Name=p.Name;
                currentUser.Surname=p.Surname;
                currentUser.PhoneNumber=p.PhoneNumber;
                currentUser.ImageUrl=p.ImageUrl;
                currentUser.PasswordHash = _userManager.PasswordHasher.HashPassword(currentUser, p.Password);

                var result = await _userManager.UpdateAsync(currentUser);
                if(result.Succeeded)
                {
                    return RedirectToAction("SingIn", "Login");
                }
            }
            return View();
        }

        

    }
}

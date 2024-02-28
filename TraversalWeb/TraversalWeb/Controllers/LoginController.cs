using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalWeb.Models;

namespace TraversalWeb.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{

		// Identity Kütüphanesi ile giriş yapmak için UserManager ve SignInManager ı kullanıyoruz
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult SingUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SingUp(SingUpUserViewModel model)
		{
			AppUser appUser = new AppUser()
			{
				Name = model.name,
				Surname = model.surname,
				Email = model.Mail,
				UserName = model.username
			};

			if (model.password==model.confirmPassowrd)
			{
				var result = await _userManager.CreateAsync(appUser,model.password);
				if (result.Succeeded)
				{
					return RedirectToAction("SingIn");
				}
				else
				{
					foreach(var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult SingIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SingIn(SingInUserViewModel p)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.userName, p.password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index","Destination");
				}
			
			}
			
			
			return View();
		}

	}
}

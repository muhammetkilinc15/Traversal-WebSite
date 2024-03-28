using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Controllers
{
	[AllowAnonymous]
	public class DestinationController : Controller
	{
		private DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());


		private readonly UserManager<AppUser> userManager;

		public DestinationController(UserManager<AppUser> userManager)
		{
			this.userManager = userManager;
		}

		public IActionResult Index()
		{
			var values = destinationManager.TGetList();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> DestinationDetails(int id)
		{
			Destination currentDestination = destinationManager.TGetDestinationByGuide(id);
			ViewBag.v1 = currentDestination.Details1;
			ViewBag.v2 = currentDestination.Details2;
			ViewBag.coverImage = currentDestination.CoverImage;
			ViewBag.Image2 = currentDestination.Image2;



			var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.destinationID = currentDestination.DestinationID;
			ViewBag.appUserID = currentUser.Id;
			return View(currentDestination);
		}

	}
}

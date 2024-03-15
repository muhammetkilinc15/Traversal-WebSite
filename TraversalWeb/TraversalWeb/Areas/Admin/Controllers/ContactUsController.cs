using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactUsController : Controller
	{
		private readonly IContactUsService _contactUsService;

		public ContactUsController(IContactUsService contactUsService)
		{
			_contactUsService = contactUsService;
		}

		public IActionResult Index()
		{
			var values = _contactUsService.TGetListByActive();
			return View(values);
		}
	}
}

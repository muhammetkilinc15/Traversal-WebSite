using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Member.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

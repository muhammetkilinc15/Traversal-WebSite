using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Error404(int code)
		{
			return View();
		}
	}
}

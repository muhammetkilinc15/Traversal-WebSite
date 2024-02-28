using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

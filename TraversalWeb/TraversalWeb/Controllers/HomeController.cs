using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraversalWeb.Models;

namespace TraversalWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime d = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            _logger.LogInformation(d+"Index Sayfasý Çaðrýldý");
            _logger.LogError("Error log Çaðýrýldý");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation($"Privacy sayfasý çaðýrýldý");
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfasý çaðýrýldý");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

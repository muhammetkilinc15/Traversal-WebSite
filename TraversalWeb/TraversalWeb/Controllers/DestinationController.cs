using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Controllers
{
    public class DestinationController : Controller
    {
        private DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            Destination currentDestination = destinationManager.TGetByID(id);
            ViewBag.v1 = currentDestination.Details1;
            ViewBag.v2 = currentDestination.Details2;
            return View(currentDestination);
        }
       
    }
}

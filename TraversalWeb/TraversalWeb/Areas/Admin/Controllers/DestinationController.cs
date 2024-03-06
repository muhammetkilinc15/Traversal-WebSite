using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DestinationController : Controller
	{

		private readonly IDestinationService _destinationService;

		public DestinationController(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}

		public IActionResult Index()
		{
			var values = _destinationService.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddDestination()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddDestination(Destination p)
		{
			_destinationService.TAdd(p);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteDestination(int id)
		{
			var deletedId= _destinationService.TGetByID(id);
			_destinationService.TRemove(deletedId);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateDestination(int id)
		{
			var currentDestination = _destinationService.TGetByID(id);
			return View(currentDestination);
		}
		[HttpPost]
		public IActionResult UpdateDestination(Destination p)
		{
			p.Status = true;
			_destinationService.TUpdate(p);
			return RedirectToAction("Index");
		}
	}
}

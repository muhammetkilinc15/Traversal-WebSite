using BusinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TraversalWeb.Areas.Admin.Models;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CityController : Controller
	{
		private readonly IDestinationService _destinationService;

		public CityController(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CityList()
		{
			var jsonConvert = JsonConvert.SerializeObject(_destinationService.TGetList());
			return Json(jsonConvert);
		}

		[HttpPost]
		public IActionResult AddCityDestination(Destination p)
		{
			p.Status = true;
			_destinationService.TAdd(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}

		public IActionResult DeleteCityDestination(Destination p)
		{
			_destinationService.TAdd(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}

		[HttpGet]
		public IActionResult GetByID(int id)
		{
			var values = _destinationService.TGetByID(id);
			var jsonValue = JsonConvert.SerializeObject(values);
			return Json(jsonValue);
		}
	}
}

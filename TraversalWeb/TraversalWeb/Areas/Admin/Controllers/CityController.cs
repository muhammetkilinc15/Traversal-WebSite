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
		[HttpPost]
		public IActionResult DeleteCityDestination(int id)
		{
			var value = _destinationService.TGetByID(id);
			_destinationService.TRemove(value);
			return NoContent();
		}

		[HttpPost]
		public IActionResult UpdateCity(Destination p)
		{
			var value = _destinationService.TGetByID(p.DestinationID);
			value.DestinationID = p.DestinationID;
			value.City = p.City;
			value.Price= p.Price;
			_destinationService.TUpdate(value);
			var jsonValue = JsonConvert.SerializeObject(p);
			return Json(jsonValue);
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

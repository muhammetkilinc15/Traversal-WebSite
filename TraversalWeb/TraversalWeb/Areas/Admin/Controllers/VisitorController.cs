using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TraversalWeb.Areas.Admin.Models;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("/Admin/[controller]/[action]/{id?}")]
	public class VisitorController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public VisitorController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:47207/api/Visitor");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddVisitor()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddVisitorAsync(VisitorViewModel p)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(p);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:47207/api/Visitor", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(p);
		}
		public async Task<IActionResult> DeleteVisitor(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responMessage = await client.DeleteAsync($"http://localhost:47207/api/Visitor/{id}");
			if (responMessage.IsSuccessStatusCode)
			{
				return RedirectToAction();
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateVisitor(int id)
		{
			var client = (_httpClientFactory.CreateClient());
			var responceMessage = await client.GetAsync($"http://localhost:47207/api/Visitor/{id}");
			if (responceMessage.IsSuccessStatusCode)
			{
				var jsonData = await responceMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
				return View(value);
			}
			return View();
		}

		
		[HttpPost]
		public async Task<IActionResult> UpdateVisitor(VisitorViewModel p)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(p);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:47207/api/Visitor", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
			
		}
	}
}

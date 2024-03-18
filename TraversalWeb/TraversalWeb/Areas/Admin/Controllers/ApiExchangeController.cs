using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalWeb.Areas.Admin.Models;

namespace TraversalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "X-RapidAPI-Key", "6ffbbe5578msha590042432168efp1a339cjsnf5f49a7f8759" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var values = JsonConvert.DeserializeObject<BookingChangeViewModel2>(body);
                return View(values.data.exchange_rates);
            }

        }
    }
}

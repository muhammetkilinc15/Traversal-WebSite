using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalWeb.Areas.Admin.Models;
using System.Net.Http.Headers;
using DocumentFormat.OpenXml.Wordprocessing;
namespace TraversalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "1e9cd31f2fmsh8c7942f19204192p1782c5jsnf51da6c56f87" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ApiMovieModel>>(body);
                return View(values);
            }
        }
    }
}

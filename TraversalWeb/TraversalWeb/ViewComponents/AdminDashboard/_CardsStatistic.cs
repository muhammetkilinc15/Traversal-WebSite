using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.AdminDashboard
{
    public class _CardsStatistic: ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Reservations.Count();
            return View();
        }
    }
}

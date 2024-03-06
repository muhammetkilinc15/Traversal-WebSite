using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.AdminDashboard
{
    public class _TotalRevenue:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

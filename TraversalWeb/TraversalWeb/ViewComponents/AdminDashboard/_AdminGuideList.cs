using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.AdminDashboard
{
    public class _AdminGuideList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

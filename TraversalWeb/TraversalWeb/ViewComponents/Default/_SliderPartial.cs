using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.Default
{
	public class _SliderPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

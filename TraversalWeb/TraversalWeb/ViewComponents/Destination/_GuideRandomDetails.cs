using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.Destination
{
	public class _GuideRandomDetails:ViewComponent
	{
		private readonly IGuideService _guideService;


		public _GuideRandomDetails(IGuideService guideService)
		{
			_guideService = guideService;
		}

		public IViewComponentResult Invoke()
		{	
			var value = _guideService.TGetByID(2);
			return View(value);
		}
	}
}

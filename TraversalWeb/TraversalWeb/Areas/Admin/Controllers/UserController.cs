using BusinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IAppUserService _userService;
		private readonly IReservationService _reservationService;

		public UserController(IAppUserService userService, IReservationService reservationService)
		{
			_userService = userService;
			_reservationService = reservationService;
		}

		public IActionResult Index()
		{
			var values = _userService.TGetList();
			return View(values);
		}
		[HttpPost]
		public IActionResult DeleteUser(int id)
		{
			var user = _userService.TGetByID(id);
			_userService.TRemove(user);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateUser(int id)
		{
			return View();
		}
		[HttpPost]
		public IActionResult UpdateUser(AppUser p)
		{
			_userService.TUpdate(p);
			return RedirectToAction("Index");
		}

		public IActionResult CommentUser(int id)
		{

			return View();
		}

		public IActionResult ReservationUser(int id)
		{

			var values = _reservationService.TGetListPrevious(id);
			return View(values);
		}
	}
}

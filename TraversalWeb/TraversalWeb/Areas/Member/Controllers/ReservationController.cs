using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalWeb.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {

        // Dependcy Injection Kullanarak iş yaptım
        private IReservationService reservationService;
        private IDestinationService destinationService;
        private readonly UserManager<AppUser> _appUser;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> appUser)
        {
            this.reservationService = reservationService;
            this.destinationService = destinationService;
            _appUser = appUser;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _appUser.FindByNameAsync(User.Identity.Name);
            var values = reservationService.TGetListCurrent(user.Id);
            return View(values);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var user = await _appUser.FindByNameAsync(User.Identity.Name);
            var values = reservationService.TGetListPrevious(user.Id);
            return View(values);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var user = await _appUser.FindByNameAsync(User.Identity.Name);
            var values = reservationService.TGetListApproval(user.Id);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewsReservation()
        {
            List<SelectListItem> citiy = (from x in destinationService.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.City,
                                              Value = x.DestinationID.ToString()
                                          }).ToList();
            ViewBag.cities = citiy;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewsReservation(Reservation p)
        {
            var user = await _appUser.FindByNameAsync(User.Identity.Name);
            p.AppUserID = user.Id;
            p.ReservationStatusID = 1;
            reservationService.TAdd(p);

            return RedirectToAction("MyCurrentReservation");
        }
    }
}

using BusinessLayer.Abstract.AbstractUnitOfWork;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet] 
        public IActionResult UpdateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAccount(Account p)
        {
            return View(p);
        }
    }
}

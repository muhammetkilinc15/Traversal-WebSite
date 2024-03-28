using BusinessLayer.Abstract.AbstractUnitOfWork;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalWeb.Areas.Admin.Models;

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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel p)
        {
            var valueSender = _accountService.TGetByID(p.SenderID);
            var valueReciever = _accountService.TGetByID(p.RecieverId);
            valueSender.Balance -= p.Amount;
            valueReciever.Balance += p.Amount;

            List<Account> accounts = new List<Account>()
            {
                valueSender,
                valueReciever
            };
            _accountService.TMultiUpdate(accounts);
            return View(p);
        }
    }
}

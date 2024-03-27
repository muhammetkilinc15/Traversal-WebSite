using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalWeb.CQRS.Commands.GuideCommands;
using TraversalWeb.CQRS.Queries.GuideQueries;

namespace TraversalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class GuideMediaRController : Controller
    {
        private readonly IMediator mediator;

        public GuideMediaRController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AddGuide()
        {
            return View();
        }

        public async Task<IActionResult> RemoveGuide(int id)
        {
            mediator.Send(new RemoveGuideCommand(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}

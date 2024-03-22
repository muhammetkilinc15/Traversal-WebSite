using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalWeb.CQRS.Commands.DestinationCommands;
using TraversalWeb.CQRS.Handlers.DestinationHandlers;
using TraversalWeb.CQRS.Queries.DestinationQueries;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("/Admin/[controller]/[action]/{id?}")]
	public class DestinationCQRSController : Controller
	{
		private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
		private readonly GetDestinationIdQeueryHandler _getDestinationQeueryHandler;
		private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
		private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
		private readonly UpdateDestinationHandler _updateDestinationCommandHandler;
        public DestinationCQRSController(GetAllDestinationQueryHandler queryHandler, GetDestinationIdQeueryHandler qeueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = queryHandler;
            _getDestinationQeueryHandler = qeueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }
        [HttpGet]
		public IActionResult Index()
		{
			var values = _getAllDestinationQueryHandler.Handle();

			return View(values);
		}
       
        public IActionResult GetDestination(int id)
		{
			var values = _getDestinationQeueryHandler.Handle(new GetDestinationByIdQuery(id));
			return View(values);
		}

        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Update(command);

            return RedirectToAction("Index");
        }




        [HttpGet]
		public IActionResult AddDestination()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddDestination(CreateDestinationCommand command)
		{
			_createDestinationCommandHandler.Handle(command);
			return RedirectToAction("Index");
		}
		public IActionResult RemoveDestination(int id)
		{
			_removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
			return RedirectToAction("Index");
		}
	}
}

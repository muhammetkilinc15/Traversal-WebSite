using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		private readonly ICommentService commentService;

		public CommentController(ICommentService commentService)
		{
			this.commentService = commentService;
		}

		public IActionResult Index()
		{
			var values = commentService.TGetListWithByDestination();
			return View(values);
		}

		[HttpPost]
		public IActionResult DeleteComment(int id)
		{
			var value = commentService.TGetByID(id);
			this.commentService.TRemove(value);
			return RedirectToAction("Index");
		}
	}
}

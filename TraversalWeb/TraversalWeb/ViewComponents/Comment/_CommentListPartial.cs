using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.Comment
{
	public class _CommentListPartial:ViewComponent
	{
	private CommentManager commentManager = new CommentManager(new EfCommentDal());
		public IViewComponentResult Invoke(int id)
		{
			var values = commentManager.TGetListByDestination(id);
			ViewBag.commentNumber = values.Count();
			return View(values);
		}
	}
}

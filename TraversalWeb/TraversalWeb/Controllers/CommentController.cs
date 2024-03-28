using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager commentManager = new CommentManager(new EfCommentDal());
    

		public PartialViewResult Index(int id)
        {
			var values = commentManager.TGetListByDestination(id);
			ViewBag.commentNumber = values.Count();
			return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {   

			return PartialView();
        }
        [HttpPost]
        public IActionResult AddCommenT(Comment p)
        {
           
            p.CommentUser = "sd";
            p.CommentDate = DateTime.Now;
            p.Status = true;
            commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}

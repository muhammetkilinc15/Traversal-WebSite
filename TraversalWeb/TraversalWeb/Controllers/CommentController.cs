using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager commentManager = new CommentManager(new EfCommentDal());


        public PartialViewResult Index(int id=6)
        {
			var values = commentManager.TGetListByDestination(id);
			ViewBag.commentNumber = values.Count();
			return PartialView(values);
        }

        [HttpGet]
        public IActionResult AddComment(Comment comment ,int id=6 )
        {            
            Comment c = new Comment();
            return PartialView(c);
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {    
            p.CommentDate = DateTime.Now;
            p.Status = true;
            commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}

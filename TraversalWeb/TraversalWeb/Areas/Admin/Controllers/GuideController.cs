using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        [Route("AddGuide")]

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();  
        }


        [HttpPost]
        public IActionResult AddGuide(Guide p)
        {
            GuideValidator guideValidator = new GuideValidator();
            ValidationResult result = guideValidator.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                _guideService.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);        
        }

        [Route("EditGuide/{id}")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var value = _guideService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide p)
        {
            _guideService.TUpdate(p);
            return RedirectToAction("Index");
        }
        [Route("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _guideService.TChangeStatus(id);
            return RedirectToAction("Index","Guide",  new {ærea="Admin"});
        }

    }
}

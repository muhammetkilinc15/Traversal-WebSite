using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

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

        public IActionResult ChangeStatus(int id)
        {
            var guide = _guideService.TGetByID(id);
            if (guide.Status)
            {
                guide.Status = false;
            }
            else
            {
                guide.Status = true;
            }
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

    }
}

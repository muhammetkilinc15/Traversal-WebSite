using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using TraversalWeb.Areas.Admin.Models;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("/Admin/[controller]/[action]")]
    public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
		{
			var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());		
			return View(values);
		}

		
		[HttpGet]
		public IActionResult AddAnnouncement()
		{
			return  View();
		}
        
        [HttpPost]
		public IActionResult AddAnnouncement(AnnouncementAddDTO p)
		{
			if(ModelState.IsValid)
			{
				_announcementService.TAdd(new Announcement()
				{
					Title = p.Title,
					Content = p.Content,
					Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
					Status = true
				}); 
				return RedirectToAction("Index","Announcement",new {area="Admin"});
			}
			else
			{

			}
			return View();
		}

        [Route("{id}")]
        public IActionResult DeleteAnnouncement(int id)
		{
			var value = _announcementService.TGetByID(id);
			_announcementService.TRemove(value);
			return RedirectToAction("Index", "Announcement",new {area="Admin"});
		}

		[Route("{id}")]
		[HttpGet]
		public IActionResult UpdateAnnouncement(int id)
		{
			var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetByID(id));
			return View(values);
		}

		[HttpPost]

        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO p)
        {
			if (ModelState.IsValid)
			{
				_announcementService.TUpdate(new Announcement()
				{
					AnnouncementID = p.AnnouncementID,
					Content = p.Content,
					Date = p.Date,
					Status = p.Status,
				});

                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            
          return View(p);
        }
    }
}

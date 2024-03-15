using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using TraversalWeb.Areas.Admin.Models;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Announcement")]
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

		[Route("Index")]
        public IActionResult Index()
		{
			var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());		
			return View(values);
		}

		[Route("AddAnnouncement")]
		[HttpGet]
		public IActionResult AddAnnouncement()
		{
			return  View();
		}
        [Route("AddAnnouncement")]
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
	}
}

using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concreate;

namespace TraversalWeb.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private IContactUsService contactUsService;
		private readonly IMapper mapper;

		public ContactController(IContactUsService contactUsService, IMapper mapper = null)
		{
			this.contactUsService = contactUsService;
			this.mapper = mapper;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(SendMessageDTO p)
		{
			if (ModelState.IsValid)
			{
				contactUsService.TAdd(new ContactUs()
				{
					Mail = p.Mail,
					MessageBody= p.MessageBody,
					Name = p.Name,
					Status= true,
					Subject = p.Subject,
					MessageDate = DateTime.Now
				});
				return RedirectToAction("Index","Default");
			}
			return View();
		}
	}
}

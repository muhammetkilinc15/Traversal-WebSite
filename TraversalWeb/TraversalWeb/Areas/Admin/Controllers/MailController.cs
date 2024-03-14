using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalWeb.Areas.Admin.Models;

namespace TraversalWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(MailRequest p)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAdressFrom = new MailboxAddress("Admin", "mhmmtklnc15@gmail.com");
			mimeMessage.From.Add(mailboxAdressFrom);

			MailboxAddress mailboxAdressTo = new MailboxAddress("User", p.RecieverMail);
			mimeMessage.To.Add(mailboxAdressTo);

			var bodybuild = new BodyBuilder();
			bodybuild.TextBody = p.Body;
			mimeMessage.Body = bodybuild.ToMessageBody();

			mimeMessage.Subject = p.Subject;


			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);

			client.Authenticate("mhmmtklnc15@gmail.com", "quwe hzzj qvwt luhq");

			client.Send(mimeMessage);

			client.Disconnect(true);

			return View();
		}


	}
}

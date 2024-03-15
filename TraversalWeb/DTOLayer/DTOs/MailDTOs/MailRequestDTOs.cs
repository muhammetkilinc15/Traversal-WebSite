using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MailDTOs
{
	public class MailRequestDTOs
	{
		public string? SenderMail { get; set; }
		public string? SenderName { get; set; }
		public string? RecieverMail { get; set; }
		public string? Subject { get; set; }
		public string? Body { get; set; }
	}
}

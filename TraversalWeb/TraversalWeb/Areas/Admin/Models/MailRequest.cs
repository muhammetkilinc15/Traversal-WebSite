﻿namespace TraversalWeb.Areas.Admin.Models
{
    public class MailRequest
    {
        public string ?SenderMail { get; set; }
        public string ?SenderName { get; set; }
        public string ?RecieverMail { get; set; }
        public string ?Subject { get; set; }
        public string ?Body { get; set; }
    }
}

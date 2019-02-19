using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("api/contactUs")]
    [EnableCors("*", "*", "*")]
    public class ContactUsController : ApiController
    {
        MailViaGmailService sendMailService;
        MailboxMessageService mailboxMessageService;

        public ContactUsController()
        {
            sendMailService = new MailViaGmailService();
            mailboxMessageService = new MailboxMessageService();
        }

        [HttpPost]
        [Route("sendMailToAdmin")]
        public MailboxMessage sendMailToAdmin([FromBody()]MailboxMessage message)
        {
            mailboxMessageService.AddMailboxMessage(message);
            return sendMailService.sendContactUs(message);
        }
        
    }
}

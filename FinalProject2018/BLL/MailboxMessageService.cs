using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class MailboxMessageService : BaseService
    {
        public List<MailboxMessage> GetAllMailboxMessages()
        {
            return db.MailboxMessages.ToList();
        }

        public MailboxMessage getMailboxMessageById(int id)
        {
            return db.MailboxMessages.FirstOrDefault(e => e.MailboxMessageId == id);
        }

        public MailboxMessage AddMailboxMessage(MailboxMessage mailboxMessage)
        {
            try
            {
                mailboxMessage.Date = DateTime.Now;
                mailboxMessage.IsReaden = false;
                db.MailboxMessages.Add(mailboxMessage);
                db.SaveChanges();
                return mailboxMessage;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteMailboxMessage(int id)
        {
            MailboxMessage mailboxMessage = db.MailboxMessages.FirstOrDefault(c => c.MailboxMessageId == id);
            db.MailboxMessages.Remove(mailboxMessage);
            db.SaveChanges();
        }

        public void EditMailboxMessage(MailboxMessage mailboxMessage)
        {

        }
    }
}

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
            return db.MailboxMessages.FirstOrDefault(m => m.ID == id);
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
                throw e;
            }
        }

        public void DeleteMailboxMessage(int id)
        {
            MailboxMessage mailboxMessage = db.MailboxMessages.FirstOrDefault(m=>m.ID == id);
            db.MailboxMessages.Remove(mailboxMessage);
            db.SaveChanges();
        }

        public void EditMailboxMessage(MailboxMessage mailboxMessage)
        {

        }
    }
}

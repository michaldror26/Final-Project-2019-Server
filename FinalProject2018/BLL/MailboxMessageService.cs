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

        public void AddMailboxMessage(MailboxMessage mailboxMessage)
        {
            db.MailboxMessages.Add(mailboxMessage);
        }

        public void DeleteMailboxMessage(int id)
        {
            MailboxMessage mailboxMessage = db.MailboxMessages.FirstOrDefault(c => c.MailboxMessageId == id);
            db.MailboxMessages.Remove(mailboxMessage);
        }

        public void EditMailboxMessage(MailboxMessage mailboxMessage)
        {

        }
    }
}

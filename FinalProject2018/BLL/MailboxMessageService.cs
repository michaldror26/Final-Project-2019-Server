using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    class MailboxMessageService : BaseService
    {
        public List<MailboxMessage> GetAllMailboxMessages()
        {
            return db.MailboxMessages.ToList();
        }

        public MailboxMessage getMailboxMessageById(int id)
        {
            return db.MailboxMessages.FirstOrDefault(e => e.MailboxMessageId == id);
        }
    }
}

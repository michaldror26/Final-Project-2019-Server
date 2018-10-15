using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MailboxMessage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; } //user or מערכת
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public Boolean IsReaden { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entities
{
    [Table("mailbox_message")]
    public class MailboxMessage
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Required field!")]
        public string FromName { get; set; } //user or מערכת
        [Required(ErrorMessage = "Required field!")]
        public string FromEmail { get; set; } //user or מערכת
    

        [Required(ErrorMessage = "Required field!")]
        public string Topic { get; set; }

        public string Content { get; set; }
        public string Link { get; set; }

        [DefaultValue(false)]
        public Boolean IsReaden { get; set; }
    }
}

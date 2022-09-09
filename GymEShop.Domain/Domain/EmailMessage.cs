using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Domain.Domain
{
    public class EmailMessage : BaseEntity
    {
        public string MailTo { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public bool Status { get; set; }
    }
}

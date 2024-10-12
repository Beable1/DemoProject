using CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class ContactDto:BaseDto
    {
        public string ContactUserName { get; set; }

        public string ContactMail { get; set; }

        public string ContactSubject { get; set; }

        public string ContactMessage { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact:BaseEntity
    {
       

        public string ContactUserName { get; set; }

        public string ContactMail { get; set; }

        public string ContactSubject { get; set; }

        public string ContactMessage { get; set; }

        

        public bool ContactStatus { get; set; }
    }
}

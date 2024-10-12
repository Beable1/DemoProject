using CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class WriterLoginDto:BaseDto
    {
        public string WriterMail { get; set; }

        public string WriterPassword { get; set; }
    }
}

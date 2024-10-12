using CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class WriterDto:BaseDto
    {
        public string WriterName { get; set; }
        public string WriterMail { get; set; }

        public string? WriterImage { get; set; }
        public string? WriterAbout { get; set; }
        public string WriterPassword { get; set; }
    }
}

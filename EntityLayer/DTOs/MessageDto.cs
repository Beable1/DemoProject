using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class MessageDto
    {

        public int MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public bool MessageStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }

    }
}

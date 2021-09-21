using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        //[StringLength(50)]
        public string SenderMail { get; set; }


        //[StringLength(50)]
        public string RecieverMail { get; set; }


        [StringLength(30)]
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageRead { get; set; }

        [StringLength(2000)]
        public string FileName { get; set; }

        public bool MessageStatus { get; set; }
    }
}

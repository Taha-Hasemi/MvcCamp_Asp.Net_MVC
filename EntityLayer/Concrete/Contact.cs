using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string UserName { get; set; }
        
        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string UserMail { get; set; }

        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string Subject { get; set; }

        public string Message { get; set; }

        public bool MessageRead { get; set; }

        public DateTime MessageDate { get; set; }

        public bool MessageStatus { get; set; }

    }
}

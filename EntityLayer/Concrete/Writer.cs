using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string WriterName { get; set; }

        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string WriterSurName { get; set; }

        [StringLength(500)]
        public string WriterImage { get; set; }

        [StringLength(500, ErrorMessage = "200 karakterden fazla giremezsiniz!")]
        public string WriterAbout { get; set; }

        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string WriterMail { get; set; }

        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string WriterPassword { get; set; }

        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}

 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        
        [StringLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz!")]
        public string CategoryName { get; set; }

        [StringLength(200, ErrorMessage = "200 karakterden fazla giremezsiniz!")]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }
    }
}

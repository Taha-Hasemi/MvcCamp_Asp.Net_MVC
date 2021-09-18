using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        [StringLength(30)]
        public string RoleName { get; set; }
        [StringLength(15)]
        public string RoleColor { get; set; }


        public int AdminID { get; set; }
        public Admin Admin { get; set; }

    }
}

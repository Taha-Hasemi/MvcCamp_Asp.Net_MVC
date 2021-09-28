using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(30)]
        public string AdminUserName { get; set; }

        [StringLength(30)]
        public string AdminPassword { get; set; }

        [StringLength(40)]
        public string AdminMail { get; set; }

        public bool AdminStatus { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill
    {   
        [Key]
        public int SkillID { get; set; }

        public string Skill1 { get; set; }

        public string Skill2 { get; set; }

        public string Skill3 { get; set; }

        public int Rate1 { get; set; }

        public int Rate2 { get; set; }

        public int Rate3 { get; set; }

        public string Name { get; set; }
    }
}

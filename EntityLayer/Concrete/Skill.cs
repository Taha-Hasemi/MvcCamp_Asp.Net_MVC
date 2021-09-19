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

        public string Name { get; set; }

        public int CSharp { get; set; }

        public int SQL { get; set; }

        public int DotNet { get; set; }

        public int AspDotNet { get; set; }

        public int Algorithm { get; set; }
        
        public int PhotoShop { get; set; }
        
        public int WindowsForm { get; set; }
        
        public int ConsoleForm { get; set; }
        
        public int EntityFramework { get; set; }
        
        public int PubgM24 { get; set; }
    }
}

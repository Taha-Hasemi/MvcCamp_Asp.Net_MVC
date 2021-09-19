using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface ISkillService
    {
        List<Skill> List();
        void SkillAdd(Skill skill);
        Skill GetByID(int id);
        void DeleteSkill(Skill skill);
        void SkillUpdate(Skill skill);
    }
}

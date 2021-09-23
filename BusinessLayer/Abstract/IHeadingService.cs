using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> List();
        List<Heading> ListActive();
        void HeadingAdd(Heading heading);
        Heading GetByID(int id);
        void DeleteHeading(Heading heading);
        void HeadingUpdate(Heading heading);
        Heading Belong(int writerID, int headingID);
    }
}

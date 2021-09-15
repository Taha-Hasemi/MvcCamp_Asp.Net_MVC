using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> List();
        void WriterAdd(Writer category);
        Writer GetByID(int id);
        void WriterDelete(Writer category);
        void WriterUpdate(Writer category);
    }
}

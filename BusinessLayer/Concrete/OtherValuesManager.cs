using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OtherValuesManager : IOtherValuesService
    {
        IOtherValuesDal _otherValuesDal;

        public OtherValuesManager(IOtherValuesDal otherValuesDal)
        {
            _otherValuesDal = otherValuesDal;
        }

        public string GetFileName()
        {
            OtherValues otherValues = new OtherValues();

            //int deger = int.Parse(_otherValuesDal.List(x => x.OtherID == 1).Select(x=>new { x.FileName }));

            otherValues = _otherValuesDal.Get(x => x.OtherID == 1);
            otherValues.FileName += 1;
            _otherValuesDal.Update(otherValues);
            otherValues = _otherValuesDal.Get(x => x.OtherID == 1);

            return otherValues.FileName.ToString();
        }
    }
}

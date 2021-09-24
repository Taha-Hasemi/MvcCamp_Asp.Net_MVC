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
    public class WriterManager : IWriterService
    {

        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> List()
        {
            return _writerDal.List().OrderByDescending(x => x.WriterID).ToList();
        }

        public Writer Login(Writer writer)
        {
            //Hashing
            //byte[] veridizim = ASCIIEncoding.ASCII.GetBytes(writer.WriterPassword);
            //writer.WriterPassword = Convert.ToBase64String(veridizim);

            //byte[] veridizim2 = ASCIIEncoding.ASCII.GetBytes(writer.WriterMail);
            //writer.WriterMail = Convert.ToBase64String(veridizim2);

            return _writerDal.List().FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }

        public List<Writer> List(string word)
        {
            return _writerDal.List(x => (x.WriterName + " " + x.WriterSurName).Contains(word)).OrderByDescending(x => x.WriterID).ToList();
        }
    }
}

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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public Content Belong(int writerID, int contentID)
        {
            return _contentDal.Get(x => x.ContentID == contentID && x.WriterID == writerID);
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public void DeleteContent(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> List()
        {
            return _contentDal.List();
        }

        public List<Content> List(string word)
        {
            return _contentDal.List(x => x.ContentValue.Contains(word) || x.Heading.HeadingName.Contains(word)).OrderByDescending(x => x.ContentID).ToList();
        }

        public List<Content> ListByHeadingID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> ListByWriterID(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }
    }
}

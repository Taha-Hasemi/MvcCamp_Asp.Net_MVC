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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void DeleteImage(ImageFile heading)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImageAdd(ImageFile heading)
        {
            throw new NotImplementedException();
        }

        public void ImageUpdate(ImageFile heading)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> List()
        {
            return _imageFileDal.List();
        }
    }
}

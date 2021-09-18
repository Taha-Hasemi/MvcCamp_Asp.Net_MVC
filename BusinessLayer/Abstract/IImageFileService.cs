using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> List();
        void ImageAdd(ImageFile heading);
        ImageFile GetByID(int id);
        void DeleteImage(ImageFile heading);
        void ImageUpdate(ImageFile heading);
    }
}

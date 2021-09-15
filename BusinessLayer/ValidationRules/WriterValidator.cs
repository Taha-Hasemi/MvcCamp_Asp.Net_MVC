using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsinizİ");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsinizİ");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mail'ni Boş Geçemezsinizİ");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar Şifresini Boş Geçemezsinizİ");

            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar Adı 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar Soyadı 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.WriterMail).MaximumLength(50).WithMessage("Yazar Maili 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.WriterPassword).MaximumLength(50).WithMessage("Yazar Şifresi 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.WriterAbout).MaximumLength(500).WithMessage("Yazar Hakkında kısmı 500 Karakterden Fazla Olamaz");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Yazar Ünvan kısmı 50 Karakterden Fazla Olamaz");

            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Yazar Adı 3 Karakterden Az Olamaz");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Yazar Soyadı 3 Karakterden Az Olamaz");
            RuleFor(x => x.WriterMail).MinimumLength(3).WithMessage("Yazar Maili 3 Karakterden Az Olamaz");
            RuleFor(x => x.WriterPassword).MinimumLength(3).WithMessage("Yazar Şifresi 3 Karakterden Az Olamaz");
        }
    }
}

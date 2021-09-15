using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator :AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.RecieverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz!");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter konu giriniz!");
            RuleFor(x => x.RecieverMail).EmailAddress().WithMessage("Lütfen doğru mail adresi giriniz!");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Lütfen 20 karakterden az konu giriniz!");

        }
    }
}

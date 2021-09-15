﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu en Az 3 Karakter Olmalı");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı en Az 3 Karakter Olmalı");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu en fazla 50 Karakter Olmalı");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Kullanıcı Adı en fazla 30 Karakter Olmalı");
        }
    }
}

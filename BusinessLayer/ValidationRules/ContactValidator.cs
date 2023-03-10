using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim kısmı boş geçilemez");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim kısmı boş geçilemez");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
        }
    }
}

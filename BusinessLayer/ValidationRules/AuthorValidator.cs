using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazar mesleği boş geçilemez");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar görseli boş geçilemez");
            RuleFor(x => x.AboutShort).NotEmpty().WithMessage("Yazar hakkında kısmı boş geçilemez");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar yetenekleri kısmı boş geçilemez");
            RuleFor(x => x.AuthorAbout).MaximumLength(250).WithMessage("En fazla 250 karakter giriniz");
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Mail kısmı boş geçilemez");
            RuleFor(x => x.AuthorMail).MinimumLength(10).WithMessage("En az 10 karakter giriniz");
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez");
            RuleFor(x => x.AuthorPhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez");

        }
    }
}
